module CPU(
        input CLK,             
        input Reset,      
        input [15:0]sw_i     
    );

	wire [31:0] PC;
	wire [31:0] PCOut;

    wire[6:0] op;        
    wire [2:0] funct3;
    wire [6:0] funct7;
	wire [4:0] addr_rs1;
	wire [4:0] addr_rs2;
	wire [4:0] addr_rd;
	wire [24:0] imm;
	wire [31:0] instr;

	wire Branch;        
    wire MemRead;     
    wire [1:0]MemToReg;     
    wire MemWrite; 
    wire [1:0]ALUSrc;       
    wire RegWrite; 
    wire [2:0]jump; 
	
	wire [31:0] WriteData;
	wire [31:0] ReadData1;
	wire [31:0] ReadData2;

	wire [31:0] extend;
	wire [31:0] ALUData1;
	wire [31:0] ALUData2;
	wire [3:0] AOp;
	wire Zero;
	wire [31:0] AluResult;

    wire [31:0] ReadData;  
    wire stall;
    wire flush;


	PC pc(
    .CLK(CLK),      
    .Reset(Reset),   
    .PCOut(PCOut),   
    .curPC(PC),
    .stall(stall),
    .flush(flush)
	);

    wire [31:0] NextPC;
    PCadd1 pcNextadder(
    .PCIn(PC),
    .PCOut(NextPC)
    );

    InsMEM insmem(
    .PC(PC),   
    .op(op),       
    .funct3(funct3), 
    .funct7(funct7), 
    .addr_rs1(addr_rs1),       
    .addr_rs2(addr_rs2),       
    .addr_rd(addr_rd),            
    .instr(instr)   
    );
    
    wire [31:0]IFIDinstr;
    wire [31:0]IFIDAddr;
    
	wire [18:0] IDEXcontrols;
    wire [31:0] IDEXdata1;
    wire [31:0] IDEXdata2;
    wire [31:0] IDEXextend;
    wire [31:0] IDEXAddr;
    wire [4:0] IDEXrs1;
    wire [4:0] IDEXrs2;
    wire [4:0] IDEXrd;
    
    wire [18:0] MEMWBcontrols;
    wire [31:0] MEMWBresult;
    wire [31:0] MEMWBdata;
    wire [31:0] MEMWBextend;
    wire [31:0] MEMWBretAddr;
    wire [4:0] MEMWBrd;
    
    wire [18:0] EXMEMcontrols;
    wire EXMEMZero;
    wire [31:0] EXMEMresult;
    wire [31:0] EXMEMData2;
    wire [31:0] EXMEMextend;
    wire [31:0] EXMEMPCRelAddr;
    wire [31:0] EXMEMretAddr;
    wire [4:0] EXMEMrd;

    IFID myIFID(
    .CLK(CLK),
    .Reset(Reset),
    .instrIn(instr),
    .AddrIn(PC),
    .flush(flush),
    .stall(stall),
    .instrOut(IFIDinstr),
    .AddrOut(IFIDAddr)
    );
    wire [2:0]Cfunct3;
    wire right;
    Control control(     
    .Reset(Reset),
    .flush(flush),
    .instr(IFIDinstr),
    .Branch(Branch),     
    .jump(jump),
    .right(right),
    .funct3(Cfunct3),
    .MemRead(MemRead),
	.MemToReg(MemToReg),
	.MemWrite(MemWrite),
	.ALUSrc(ALUSrc),
	.RegWrite(RegWrite),
	.AP(AOp)
    );
    
    wire [18:0]controls;
    assign controls=/*flush?0:(!Reset)?0:*/{right/*[18]*/,Cfunct3/*[17:15]*/,jump/*[14:12]*/,Branch/*[11]*/,MemRead/*[10]*/,MemToReg/*[9:8]*/,MemWrite/*[7]*/,ALUSrc/*[6:5]*/,RegWrite/*[4]*/,AOp/*[3:0]*/};
    
   	RegisterFile regfile(
    .CLK(CLK),
    .Reset(Reset),
	.addr_rs1(IFIDinstr[19:15]),       
    .addr_rs2(IFIDinstr[24:20]),
       
    .addr_rd(MEMWBrd), 
    .WriteData(WriteData),
	.RegWrite(MEMWBcontrols[4]),
            
    .ReadData1(ReadData1), 
    .ReadData2(ReadData2)
    );

	ImmGen immg(
	.instr(IFIDinstr),
	.Reset(Reset),
	.extend(extend)
	);
	
	IDEX myIDEX(
	CLK,
	Reset,
	flush,
	stall,
	controls,
	ReadData1,
	ReadData2,
	extend,
	IFIDAddr,
	IFIDinstr[11:7],
	IFIDinstr[19:15],
	IFIDinstr[24:20],
	IDEXcontrols,
	IDEXdata1,
	IDEXdata2,
	IDEXextend,
	IDEXAddr,
	IDEXrd,
	IDEXrs1,
	IDEXrs2
	);

    Stall mystall(
    IFIDinstr[19:15],
    IFIDinstr[24:20],
    IDEXcontrols[10],
    IDEXrd,
    MEMWBcontrols[4],
    MEMWBrd,
    stall
    );

    wire[2:0]forward1;
    wire[2:0]forward2;
    wire[31:0]FWDdata1;
    wire[31:0]FWDdata2;

    MuxFWD myMuxFWD(
    IDEXdata1,
    IDEXdata2,
    EXMEMresult,
    WriteData,
    forward1,
    forward2,
    FWDdata1,
    FWDdata2
    );

    MuxRtoALU muxrtoalu(
	.extend(IDEXextend),
	.ReadData2(FWDdata2),
	.ReadData1(FWDdata1),
	.PC(IDEXAddr),
	.ALUSrc(IDEXcontrols[6:5]),
	.right(IDEXcontrols[18]),
	.ALUData1(ALUData1),
	.ALUData2(ALUData2)
	);

    ALU alu(
    .CLK(CLK),
    .ALUData1(ALUData1),    
    .ALUData2(ALUData2),     
    .AOp(IDEXcontrols[3:0]),
    .jump(IDEXcontrols[14:12]),
    .Zero(Zero),
	.AluResult(AluResult)
    );

    FWD myfwd(
    IDEXrs1,
    IDEXrs2,
    EXMEMcontrols[4],
    EXMEMrd,
    MEMWBcontrols[4],
    MEMWBrd,
    forward1,
    forward2);

    wire[31:0]pcADD1;
    wire[31:0]pcADDextend;
    PCadd1 add1(
    .PCIn(IDEXAddr),
    .PCOut(pcADD1)
    );
    PCaddExtend addextend(
    .PCIn(IDEXAddr),
    .ExtendIn(IDEXextend),
    .PCOut(pcADDextend)
    );
    
    AddPC addpc(
	.PCaddExtend(pcADDextend),
	.NextPC(NextPC),
	.result(AluResult),
	.jump(IDEXcontrols[14:12]),
	.extend(IDEXextend),
	.Zero(Zero),
	.Branch(IDEXcontrols[11]),
	.PCOut(PCOut)
	);
    
    Flush myflush(
    .zeroIn(Zero),
    .jumpIn(IDEXcontrols[14:12]),
    .BranchIn(IDEXcontrols[11]),
    .flushOut(flush)
    );
    
    EXMEM myEXMEM(
    CLK,
    Reset,
    flush,
    IDEXcontrols,
    Zero,
    AluResult,
    FWDdata2,
    IDEXextend,
    pcADDextend,
    pcADD1,
    IDEXrd,
    EXMEMcontrols,
    //EXMEMless,
    EXMEMZero,
    EXMEMresult,
    EXMEMPCRelAddr,
    EXMEMData2,
    EXMEMextend,
    EXMEMretAddr,
    EXMEMrd
    );

   	DataMEM datamem(
    .MemWrite(EXMEMcontrols[7]),
    .MemRead(EXMEMcontrols[10]), 
    .CLK(CLK),  
    .funct3(EXMEMcontrols[17:15]),  
    .Reset(Reset),
    .Addr(EXMEMresult),  
    .WriteData(EXMEMData2),
    .sw_i(sw_i),
    //.portOut(portOut),
    .ReadData(ReadData) 
    );
	
	MEMWB myMEMWB(
	.CLK(CLK),
	.Reset(Reset),
	.controlsIn(EXMEMcontrols),
	.resultIn(EXMEMresult),
	.ReadDataIn(ReadData),
	.ExtendIn(EXMEMextend),
	.retAddrIn(EXMEMretAddr),
	.rdIn(EXMEMrd),
	.controlsOut(MEMWBcontrols),
	.resultOut(MEMWBresult),
	.ReadDataOut(MEMWBdata),
	.ExtendOut(MEMWBextend),
	.retAddrOut(MEMWBretAddr),
	.rdOut(MEMWBrd)
	);
	
	MuxMemtoR muxmemtor(
	.ResultIn(MEMWBresult),
	.MemDataIn(MEMWBdata),
	.NeAddrIn(MEMWBretAddr),
	.MemToReg(MEMWBcontrols[9:8]),
	.WriteData(WriteData)
	);

endmodule
