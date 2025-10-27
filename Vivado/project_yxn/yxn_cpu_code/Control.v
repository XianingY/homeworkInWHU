`include "AluOp.vh"
module Control(     
        input [31:0]instr,
        input flush,
        input Reset,
        output wire[2:0] jump,    
        output reg Branch,       
        //output reg[1:0] ALUOp,  
        output wire[3:0] AP,
        output reg MemRead,     
        output reg [1:0]MemToReg,     
        output reg MemWrite, 
        output reg [1:0]ALUSrc,       
        output reg RegWrite, 
        output wire [2:0]funct3,
        output reg right
    );
wire [6:0]op;
wire [6:0]funct7;   
reg[1:0] ALUOp; 

//译码
assign op =(flush||!Reset)?0: instr[6:0];   
assign funct3 =(flush||!Reset)?0: instr[14:12];
assign funct7 =(flush||!Reset)?0: instr[31:25];
always@(op or funct3 or funct7 or flush or Reset)
	begin
	    if(flush||!Reset) begin
	            ALUOp = 0;
				ALUSrc = 0;
				MemToReg = 0;
				RegWrite = 0;
				MemRead = 0;
				MemWrite = 0;
				Branch = 0;
				right=0;
				end
		else if (op == 7'b0110011)//r型指令
			begin
				ALUOp = 2'b10;
				ALUSrc = 2'b00;
				MemToReg = 2'b00;
				RegWrite = 1;
				MemRead = 0;
				MemWrite = 0;
				Branch = 0;
				right=0;
			end
		else if (op==7'b0000011)//l型指令中的加载指令
			begin
				ALUOp = 2'b00;
				ALUSrc = 2'b01;
				MemToReg = 2'b01;
				RegWrite = 1;
				MemRead = 1;
				MemWrite = 0;
				Branch = 0;
				right=0;
			end
		else if (op==7'b0100011)//s型指令
			begin
				ALUOp = 2'b00;
				ALUSrc = 2'b01;
				RegWrite = 0;
				MemRead = 0;
				MemWrite = 1;
				Branch = 0;
				right=0;
			end
		else if (op==7'b1100011)//beq
			begin
				ALUOp = 2'b01;
				//AP=`alu_sub;//
				ALUSrc = 2'b00;
				RegWrite = 0;
				MemRead = 0;
				MemWrite = 0;
				Branch = 1;
				right=0;
			end
		else if (op==7'b1101111)//jal
			begin
				ALUOp = 2'b01;
				ALUSrc = 2'b00;
				MemToReg = 2'b10;
				RegWrite = 1;
				MemRead = 0;
				MemWrite = 0;
				Branch = 1;
				right=0;
			end
		else if (op==7'b1100111)//jalr
			begin
				ALUOp = 2'b01;
				ALUSrc = 2'b01;
				MemToReg = 2'b10;
				RegWrite = 1;
				MemRead = 0;
				MemWrite = 0;
				Branch = 1;
				right=1;
			end
		else if (op == 7'b0010011)//i型指令带立即数计算的指令
			begin
				ALUOp = 2'b11;
				ALUSrc = 2'b01;
				MemToReg = 2'b00;
				RegWrite = 1;
				MemRead = 0;
				MemWrite = 0;
				Branch = 0;
				right=0;
			end
		else if (op == 7'b0110111)//lui
			begin
				ALUOp = 2'b00;
				ALUSrc = 2'b10;
				MemToReg = 2'b00;
				RegWrite = 1;
				MemRead = 0;
				MemWrite = 0;
				Branch = 0;
				right=0;
			end
		else if (op == 7'b0010111)//auipc
			begin
				ALUOp = 2'b00;
				ALUSrc = 2'b11;
				MemToReg = 2'b00;
				RegWrite = 1;
				MemRead = 0;
				MemWrite = 0;
				Branch = 0;
				right=0;
			end
		else begin
		        ALUOp = 2'b00;
				ALUSrc = 2'b00;
				MemToReg = 2'b00;
				RegWrite = 0;
				MemRead = 0;
				MemWrite = 0;
				Branch = 0;
				right=0;
				 end
		end
//assign pcORreg=(op == 7'b0010111)?1:0;
		AC alucont(
		.funct3(funct3),
		.funct7(funct7),
		.op(op),
		//.flush(flush),
		.ALUOp(ALUOp),
		.AP(AP),
		.jump(jump)
		);

endmodule
