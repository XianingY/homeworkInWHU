module RegisterFile(
        input CLK, 
        input Reset,                     
        input [4:0] addr_rs1,        
        input [4:0] addr_rs2,        

        input [4:0] addr_rd,   
	    input [31:0] WriteData,
        input RegWrite,            
        
        output reg[31:0] ReadData1, 
        output reg[31:0] ReadData2  
        //input [15:0]sw_i
        //output [15:0] portOut
    );
reg [31:0] rf[31:0];
integer k;
  initial begin
      for (k = 0;k<32 ;k=k+1 ) begin
         rf[k]<=0;
      end
  end

always@(posedge CLK or negedge Reset)
    begin
    if (!Reset) begin
      for (k=0;k<32;k=k+1) rf[k]<=0;
      end
	else if (RegWrite && addr_rd!=0)
		begin 	rf[addr_rd]<=WriteData; end
	end
always@(negedge CLK or negedge Reset)
    begin
    if ((!Reset)||addr_rs1==0 )
        ReadData1<=0;
	else if (RegWrite && (addr_rd==addr_rs1))
	    ReadData1<=WriteData; 
	else 
	    ReadData1<=rf[addr_rs1]; 
	    
	if (!Reset||addr_rs2==0) begin
      ReadData2<=0;
      end
	else if (RegWrite && addr_rd==addr_rs2)
	   begin 	ReadData2<=WriteData; end
	else 
	   begin  ReadData2<=rf[addr_rs2]; end
	   
	end   


endmodule

		