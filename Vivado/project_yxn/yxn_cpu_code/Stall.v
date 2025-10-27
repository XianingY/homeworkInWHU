`timescale 1ns / 1ps



module Stall(
  input[4:0] IFIDrs1In,    //from IFID
  input[4:0] IFIDrs2In,    //from IFID
  input      IDEXMemReadIn,   //from IDEX
  input[4:0] IDEXrdIn,     //from IDEX
  (* DONT_TOUCH = "1" *)input      MAWBRegWriteIn,
  (* DONT_TOUCH = "1" *)input[4:0] MAWBrdIn,  
  output reg stallOut  //to   PC,IFID,IDEX
);

  always @(*) begin
    if ((IDEXMemReadIn)&&(IDEXrdIn==IFIDrs1In||IDEXrdIn==IFIDrs2In)) stallOut<=1;
    else stallOut<=0;
  end
endmodule
