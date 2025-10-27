`include "AluOp.vh"
module AddPC(
	input [31:0]PCaddExtend,
	input [31:0]NextPC,
	(* DONT_TOUCH = "1" *)input [31:0]extend,
	input [31:0]result,
	input [2:0]jump,
	input Zero,
	input Branch,
	output reg [31:0]PCOut
);
always@(*)
	begin
	if(jump>=0&&jump<=5)
	begin
	    if(Branch&&Zero)
		begin
		PCOut<=PCaddExtend;
		end
		else
		begin
		PCOut<=NextPC;
		end
	end	
	else if(jump==`jump_jal)
		begin
		PCOut<=PCaddExtend;
		end
	else if(jump==`jump_jalr)
		begin
		PCOut<=result;
		end	
	else
	   PCOut<=NextPC;
	end
endmodule
