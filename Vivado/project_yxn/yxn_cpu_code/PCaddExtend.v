`timescale 1ns / 1ps



module PCaddExtend(
    input [31:0]ExtendIn,
    input [31:0]PCIn,
    output [31:0]PCOut
    );
    assign PCOut=$signed($signed(ExtendIn)>>>1)+PCIn;
endmodule
