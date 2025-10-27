
`timescale 1ns / 1ps

module DataMEM(
        input MemWrite,   
	    (* DONT_TOUCH = "1" *)input MemRead,        
        input CLK,    
        input Reset,  
        input [2:0]funct3,     
        input [31:0] Addr,  
        input [31:0] WriteData, 
        input [15:0]sw_i,
        //output reg[31:0]portOut,
        output reg[31:0] ReadData
    	);
    reg [7:0] ram [50:-50];    
    reg [31:0] result;
    integer i;
    initial
    begin
        result<=32'haa5555aa;
        for(i=-50;i<51;i=i+1)
        ram[i]<=0;
    end
  	reg [31:0]ReadTemp;
  	reg [31:0]WriteTemp;
  	always@(*)
  	begin
  	//ReadTemp=MemRead?ram[Addr]:0;
  	if(Addr==32'hffff0004)
  	ReadData=sw_i;
  	else begin
  	case(funct3)
  	     3'b000:begin
  	     ReadTemp={ram[Addr][7]?24'hffffff:24'h000000,ram[Addr]};
  	     end
  	     3'b001:begin
  	     ReadTemp={ram[Addr+1][7]?16'hffff:16'h0000,ram[Addr+1],ram[Addr]};
  	     end
         3'b010:begin
         ReadTemp={ram[Addr+3],ram[Addr+2],ram[Addr+1],ram[Addr]};
         end
         3'b100:ReadTemp=({24'h000000,ram[Addr]});
         3'b101:ReadTemp=({16'h0000,ram[Addr+1],ram[Addr]});
         default:ReadTemp={ram[Addr+3],ram[Addr+2],ram[Addr+1],ram[Addr]};
  	endcase
  	         ReadData=MemRead?ReadTemp:0;  //读信号有效时读取
  	end
  	end
   //assign ReadData=MemRead?ram[$signed(Addr)>>>2]:0;
   	always@(posedge CLK or negedge Reset)
    	begin   
    	if(!Reset) begin
    	result<=32'haa5555aa;
    	for(i=-50;i<51;i=i+1) ram[i]=0;
    	end
        else if(MemWrite)
            if(Addr==32'hffff000c)
                result=WriteData;
            else begin
            begin
                case(funct3)
                3'b000:ram[Addr]=WriteData[7:0];
                3'b001:begin
                ram[Addr]=WriteData[7:0];
                ram[Addr+1]=WriteData[15:8];
                end
                3'b010:begin
                ram[Addr]=WriteData[7:0];
                ram[Addr+1]=WriteData[15:8];
                ram[Addr+2]=WriteData[23:16];
                ram[Addr+3]=WriteData[31:24];
   
                
                end
                endcase
            end
            end
    	end
endmodule
