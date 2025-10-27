`timescale 1ns / 1ps



module IDEX(  
    input CLK, //from outside
    input Reset, //from outside
    input flushIn,
    input stallIn,
    input[18:0] controlsIn, 
    input[31:0] Data1In, 
    input[31:0] Data2In, 
    input[31:0] Imm32In,
    input[31:0] AddrIn,
    input[4:0] rdIn,
    input[4:0] rs1In,
    input[4:0] rs2In,
    output reg[18:0] controlsOut, 
    output reg[31:0] Data1Out,
    output reg[31:0] Data2Out,
    output reg[31:0] Imm32Out,
    output reg[31:0] AddrOut, 
    output reg[4:0] rdOut,
    output reg[4:0] rs1Out,
    output reg[4:0] rs2Out
    );

  always @(posedge CLK or negedge Reset) begin
    if (!Reset) begin 
        controlsOut<=0; 
        AddrOut<=0;
        Data1Out<=0;
        Data2Out<=0;
        Imm32Out<=0;
        rdOut<=0;
        rs1Out<=0;
        rs2Out<=0;
        end
    else if (flushIn) begin 
        controlsOut<=0;
        Data1Out<=0;
        Data2Out<=0;
        Imm32Out<=0;
        rs1Out<=0;
        rs2Out<=0;
        AddrOut<=0;
        rdOut<=0; 
        end
    else if (stallIn==0) begin
        controlsOut<=controlsIn;
        Data1Out<=Data1In;
        Data2Out<=Data2In;
        Imm32Out<=Imm32In;
        rs1Out<=rs1In;
        rs2Out<=rs2In;
        AddrOut<=AddrIn;
        rdOut<=rdIn;
        end
    else begin 
        controlsOut<=0;
        Data1Out<=0;
        Data2Out<=0;
        Imm32Out<=0;
        rs1Out<=0;
        rs2Out<=0;
        AddrOut<=0;
        rdOut<=0; 
        end
    end
endmodule
