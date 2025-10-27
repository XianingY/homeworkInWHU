`timescale 1ns / 1ps
module PC(
        input CLK,             
        input Reset,                   
        input [31:0] PCOut, 
        input stall, 
        input flush,
        output reg[31:0] curPC  
        );
    	initial 
    	begin
        	curPC <= 0; 
    	end
    	always@(posedge CLK or negedge Reset)
    	begin
        	if(!Reset) 
            	curPC <= 0;
        	else if(stall==0)	
            	curPC <= PCOut;
            else if(flush)	
            	curPC <= PCOut;
    	end
endmodule
