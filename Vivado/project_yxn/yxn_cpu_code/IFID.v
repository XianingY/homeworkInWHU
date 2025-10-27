`timescale 1ns / 1ps



module IFID(
    input CLK,
    input Reset,
    input[31:0]instrIn,
    input[31:0]AddrIn,
    input flush,
    input stall,
    output reg [31:0]instrOut,
    output reg [31:0]AddrOut
    );

  always @(posedge CLK or negedge Reset) begin
    if (!Reset) begin instrOut<=0; AddrOut<=0; end
    else if (flush) begin instrOut<=0; AddrOut<=0; end 
    else if (stall==0) begin instrOut<=instrIn; AddrOut<=AddrIn; end
  end
endmodule
