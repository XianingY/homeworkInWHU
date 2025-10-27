`include "AluOp.vh"
module ALU(   
        (* DONT_TOUCH = "1" *)input CLK,   
        input [31:0] ALUData1, 
        input [31:0] ALUData2,   
        //input [31:0] PC,      
        input [3:0] AOp, 
        input [2:0] jump,    
        output reg Zero,   
        output reg[31:0] AluResult 
    );
    	always@(ALUData1 or ALUData2 or AOp or jump) 
    	begin
        case(AOp)
            	`alu_add: AluResult = ALUData1 + ALUData2;
            	`alu_sub: begin
            	   AluResult = ALUData1 - ALUData2;
            	   Zero=(AluResult==0)?1:0;
            	   end
            	`alu_and: AluResult = ALUData1 & ALUData2;
           	    `alu_or: AluResult = ALUData1 | ALUData2;
           	    `alu_xor:AluResult = ALUData1 ^ ALUData2;
           	    `alu_leftlogical:AluResult = ALUData1 << ALUData2;
           	    `alu_rightlogical:AluResult = ALUData1 >> ALUData2;
           	    `alu_right:AluResult =($signed(ALUData1)) >>> ALUData2;
           	    `alu_slt:AluResult = ($signed(ALUData1) < $signed(ALUData2))? 1 : 0;
           	    `alu_sltu:AluResult = ($unsigned(ALUData1) < $unsigned(ALUData2))? 1 : 0;
            	`alu_blt:begin
            	   case(jump)
            	       `jump_beq:begin
            	       AluResult = ALUData1 - ALUData2;
            	       Zero=(AluResult==0)?1:0;
            	       end
            	       `jump_bne:begin
           	           AluResult = ALUData1 - ALUData2;
            	       Zero=(AluResult==0)?0:1;
            	       end
            	       `jump_blt:begin
             	       AluResult = ALUData1 - ALUData2;
            	       Zero=(/*$signed(ALUData1)<$signed(ALUData2)*/$signed(AluResult)<0)?1:0;
            	       end
            	       `jump_bge:begin
             	       AluResult = ALUData1 - ALUData2;
            	       Zero=($signed(AluResult)<0)?0:1;
            	       end
            	       `jump_bltu:begin
                       Zero=($unsigned(ALUData1)<$unsigned(ALUData2))?1:0;
            	       end
            	       `jump_bgeu:begin
             	       Zero=($unsigned(ALUData1)>=$unsigned(ALUData2))?1:0;
            	       end
            	       `jump_jal:begin
            	       Zero=1;
            	       //AluResult=$unsigned(ALUData1+ALUData2)>>>2;
            	       end
            	       `jump_jalr:begin
            	       Zero=1;
            	       AluResult=$signed(ALUData1+ALUData2)>>>2;
            	       end
            	       default:begin
            	       Zero=0;
            	       AluResult=0;
            	       end
            	   endcase
            	   end
            default:begin
            Zero=0;
            AluResult=0;
            end
        endcase
    	end 
endmodule
