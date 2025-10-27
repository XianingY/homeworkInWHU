`timescale 1ns / 1ps



module EXMEM(  
    input CLK, //from outside
    input Reset, //from outside
    input flushIn,
    input[18:0] controlsIn, 
    input zeroIn, 
    input[31:0] resultIn,
    input[31:0] Data2In,
    input[31:0] Imm32In,
    input[31:0] PCRelAddrIn,
    input[31:0] retAddrIn,
    input[4:0] rdIn,
    output reg[18:0] controlsOut, 
    //output reg lessOut,
    output reg zeroOut,
    output reg[31:0] resultOut,
    output reg[31:0] PCRelAddrOut,
    output reg[31:0] Data2Out,
    output reg[31:0] Imm32Out,
    output reg[31:0] retAddrOut,
    output reg[4:0] rdOut
    );

  always @(posedge CLK or negedge Reset) begin
    if (!Reset) begin 
      controlsOut<=0;
      //lessOut<=0;
      zeroOut<=0;
      resultOut<=0;
      PCRelAddrOut<=0;
      Data2Out<=0;
      Imm32Out<=0;
      retAddrOut<=0;
      rdOut<=0;
      end
    else if (flushIn) begin 
        controlsOut[18:10]<=0;
        controlsOut[7:4]<=0;
        controlsOut[3:0]<=0;
        controlsOut[9:8]<=(controlsIn[9:8]==2'b10)?controlsIn[9:8]:0;
        controlsOut[4]<=(controlsIn[9:8]==2'b10)?1:0;
        //lessOut<=0;
        zeroOut<=0;
        resultOut<=0;
        Data2Out<=0;
        Imm32Out<=0;
        PCRelAddrOut<=0;
        retAddrOut<=retAddrIn;
        rdOut<=(controlsIn[9:8]==2'b10)?rdIn:0; 
        end
    else begin
        controlsOut<=controlsIn; 
        zeroOut<=zeroIn; 
        resultOut<=resultIn;
        Data2Out<=Data2In; 
        Imm32Out<=Imm32In; 
        PCRelAddrOut<=PCRelAddrIn; 
        retAddrOut<=retAddrIn; 
        rdOut<=rdIn;
        end
    end
endmodule
