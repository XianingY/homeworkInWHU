module MuxRtoALU(
	input [31:0]ReadData2,
	input [31:0]ReadData1,
	input [31:0]PC,
	input [31:0]extend,
	input [1:0]ALUSrc,
	input right,
	output reg[31:0]ALUData1,
	output reg[31:0]ALUData2
);
always@(*)
begin
    if(ALUSrc==2'b11)//auipc
    begin
        ALUData1=PC<<2;
        ALUData2=extend;
    end
    else if(ALUSrc==2'b10)//lui
    begin
        ALUData1=0;
        ALUData2=extend;
    end
    else if(ALUSrc==2'b01)
    begin
        ALUData1=ReadData1;
        ALUData2=right?(extend<<1):extend;
    end
    else
    begin
        ALUData1=ReadData1;
        ALUData2=ReadData2;
    end
end
endmodule

