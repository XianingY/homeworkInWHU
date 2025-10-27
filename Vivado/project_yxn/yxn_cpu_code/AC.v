`timescale 1ns / 1ps



`include "AluOp.vh"
module AC(
	input [1:0]ALUOp,
	input [2:0]funct3,
	(* DONT_TOUCH = "1" *)input [6:0]funct7,
	input [6:0]op,
	//input flush,
	output reg[3:0] AP,
	output reg[2:0] jump
	);

always@(funct3 or funct7 or ALUOp or op)
	begin
		case(ALUOp)
			2'b00:begin  //ld和sd
			     AP=`alu_add;
			     jump<=0;
			     end
			2'b01:begin   //跳转类型
			     AP<=`alu_blt;
			     if(op==7'b1101111) jump<=`jump_jal;
			     else if(op==7'b1100111) jump<=`jump_jalr;
			     else begin
                     case(funct3)
                     3'b000:
                         jump<=`jump_beq;//beq
                     3'b001:
                         jump<=`jump_bne;
                     3'b100:
                         jump<=`jump_blt;
                     3'b101:
                         jump<=`jump_bge;
                     3'b110:
                         jump<=`jump_bltu;
                     3'b111:
                         jump<=`jump_bgeu;
                     default:
                         jump<=0;
                     endcase
			     end
			     end
			2'b10:  //R型指令
			begin
			         jump<=0;
			         case(funct3)
			         3'b000:
			             AP=(funct7[5]==0)?`alu_add:`alu_sub;
			         3'b111:
			             AP=`alu_and;
			         3'b110:
			             AP=`alu_or;
			         3'b100:
			             AP=`alu_xor;
			         3'b001:
			             AP=`alu_leftlogical;
			         3'b101:
			             AP=(funct7[5]==1)?`alu_right:`alu_rightlogical;
			         3'b010:
			             AP=`alu_slt;
			         3'b011:
			             AP=`alu_sltu;
			         default:
			             AP=`alu_sub;
			         endcase
			end
			2'b11:  //I型指令
			begin
			     jump<=0;
			     case(funct3)
			         3'b000:
			             AP=`alu_add;
			         3'b111:
			             AP=`alu_and;
			         3'b110:
			             AP=`alu_or;
			         3'b100:
			             AP=`alu_xor;
			         3'b001:
			             AP=`alu_leftlogical;
			         3'b101:
			             AP=(funct7[5]==1)?`alu_right:`alu_rightlogical;
			         3'b010:
			             AP=`alu_slt;
			         3'b011:
			             AP=`alu_sltu;
			         default:
			             AP=`alu_sub;
			         endcase
			end 
			default:begin
			AP=0;
			jump=0;
			end
        endcase
        end
endmodule

