`timescale 1ns / 1ps


`include "AluOp.vh"
module Flush(
  input zeroIn,         //from EXMA
  input [2:0]jumpIn,
  input BranchIn,
  output flushOut   //to IFID,IDEX,EXMA
);
assign flushOut=(jumpIn==`jump_jal||jumpIn==`jump_jalr||zeroIn&&BranchIn)?1:0;
endmodule
