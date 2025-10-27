`timescale 1ns / 1ps



module MEMWB(  
    input CLK, //from outside
    input Reset, //from outside
    input[18:0] controlsIn, 
    input[31:0] resultIn,
    input[31:0] ReadDataIn, 
    input[31:0] ExtendIn,
    input[31:0] retAddrIn,
    input[4:0] rdIn,
    output reg[18:0] controlsOut, 
    output reg[31:0] resultOut,
    output reg[31:0] ReadDataOut,
    output reg[31:0] ExtendOut,
    output reg[31:0] retAddrOut, 
    output reg[4:0] rdOut
    );

  always @(posedge CLK or negedge Reset) begin
    if (!Reset) begin 
      controlsOut<=0; 
      resultOut<=0;
      ReadDataOut<=0;
      retAddrOut<=0;
      ExtendOut<=0;
      rdOut<=0;
      end
    else begin 
      controlsOut<=controlsIn; 
      resultOut<=resultIn;
      ReadDataOut<=ReadDataIn;
      retAddrOut<=retAddrIn;
      ExtendOut<=ExtendIn;
      rdOut<=rdIn;
      end
    end
endmodule
