`timescale 1ns / 1ps



module FWD(
    input[4:0]      IDEXrs1In,    //from IDEX
    input[4:0]      IDEXrs2In,    //from IDEX
    input           EXMEMwriteIn,  //from EXMEM
    input[4:0]      EXMEMrdIn,     //from EXMEM
    //input[1:0]      EXMEMDataSelectorIn,     //from EXMEM,ctrSignals for DataMUX
    input           MEMWBwriteIn,  //from MEMWB
    input[4:0]      MEMWBrdIn,     //from MEMWB
    output reg[2:0] forward1Out,     //to   FWDMUX
    output reg[2:0] forward2Out      //to   FWDMUX
);

  always @(*) begin
    if ((EXMEMwriteIn)&&(EXMEMrdIn==IDEXrs1In)&&(EXMEMrdIn!=0)) begin
        forward1Out<=2;
    end
    else if ((MEMWBwriteIn)&&(MEMWBrdIn==IDEXrs1In)&&(MEMWBrdIn!=0)) forward1Out<=1;
    else forward1Out<=0;
  end

  always @(*) begin
    if ((EXMEMwriteIn)&&(EXMEMrdIn==IDEXrs2In)&&(EXMEMrdIn!=0)) begin
        forward2Out<=2;
    end
    else if ((MEMWBwriteIn)&&(MEMWBrdIn==IDEXrs2In)&&(MEMWBrdIn!=0)) forward2Out<=1;
    else forward2Out<=0;
  end

endmodule
