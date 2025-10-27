module MuxMemtoR(
    input [31:0]ResultIn,
    input [31:0]MemDataIn,
    (* DONT_TOUCH = "1" *)input [31:0]NeAddrIn,
	input [1:0]MemToReg,
	output reg[31:0]WriteData
);

always@(*)
    begin
    case(MemToReg)
    2'b00:WriteData=ResultIn;
    2'b01:WriteData=MemDataIn;
    2'b10:WriteData=NeAddrIn<<2;
    default:WriteData=0;
    endcase
    end
endmodule
