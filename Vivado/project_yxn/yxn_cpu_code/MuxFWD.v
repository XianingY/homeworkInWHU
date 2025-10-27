`timescale 1ns / 1ps



module MuxFWD(
    input[31:0]      IDEXdata1In,
    input[31:0]      IDEXdata2In,
    input[31:0]      EXMEMresultIn,  //from EXMEM
    input[31:0]      MEMWBdataIn,
    input[2:0]       forward1In,
    input[2:0]       forward2In,
    output reg[31:0] data1Out,
    output reg[31:0] data2Out
);
 always @(IDEXdata1In,EXMEMresultIn,MEMWBdataIn,forward1In) begin
    if      (forward1In==0) data1Out<=IDEXdata1In;
    else if (forward1In==1) data1Out<=MEMWBdataIn;    //来自datameme或者更早alu计算结果
    else if (forward1In==2) data1Out<=EXMEMresultIn;  //来自上一个alu结果
    else                    data1Out<=0;
  end                         
  always @(IDEXdata2In,EXMEMresultIn,MEMWBdataIn,forward2In) begin
    if      (forward2In==0) data2Out<=IDEXdata2In;
    else if (forward2In==1) data2Out<=MEMWBdataIn;    //来自datameme或者更早alu计算结果
    else if (forward2In==2) data2Out<=EXMEMresultIn;  //来自上一个alu结果
    else                    data2Out<=0;
  end
endmodule

