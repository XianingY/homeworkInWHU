`timescale 1ns / 1ps
module TestSingleCycleCpu(
    input clk,
    input rstn,
    input[15:0] sw_i,
    output[7:0] disp_an_o,
    output[7:0] disp_seg_o
    );
    //INPUTS
    reg CLK;
    reg Reset;
    reg [31:0]disp_data;
    //reg [15:0]sw_i;
    
        initial begin
 
        CLK = 1;
        Reset = 0; 
        #2
        Reset = 0; 
        #3
        Reset = 1; 
        #5
        CLK = !CLK;
        forever #10
            begin 
             CLK = !CLK;
            end
        end
        //分频
        reg [31:0] clkdiv;
        wire Clk_CPU;
        always @ (posedge clk or negedge rstn)
        if (!rstn) clkdiv <= 0;
        else clkdiv <= clkdiv + 1'b1;
        assign Clk_CPU = (sw_i[15])? clkdiv[26] : clkdiv[22];
    
        CPU myCPU(
        //.CLK(CLK/*Clk_CPU*/),
        .CLK(Clk_CPU),
        .Reset(rstn/*rstn*/),
        //.Reset(rstn),
        .sw_i(sw_i)  
        );

    //显示，开关1显示PC，开关2显示寄存器，默认显示端口输出
    always @ (posedge clkdiv)
        if(sw_i[6]) disp_data <= myCPU.datamem.ram[sw_i[5:0]] ;     //显示内存
        else if (sw_i[5]) disp_data <= myCPU.regfile.rf[sw_i[4:0]] ;//显示寄存器
        else if (sw_i[5:0]==6'b0000000) disp_data <= myCPU.datamem.result; //显示默认的0xAA5555AA或者写入0xFFFF000C的值
        else if (sw_i[5:0]==6'b0000001) disp_data <= myCPU.PC;             //显示指令序号
        else if (sw_i[5:0]==6'b0000010) disp_data <= myCPU.PC<<2;          //显示指令地址
        else if (sw_i[5:0]==6'b0000011) disp_data <= myCPU.instr;          //显示指令
        else if (sw_i[5:0]==6'b0000100) disp_data <= myCPU.datamem.Addr ;  //显示存储器地址
        else if (sw_i[5:0]==6'b0000101) disp_data <= myCPU.datamem.WriteData ;  //显示写入存储器的数据
        else if (sw_i[5:0]==6'b0000110) disp_data <= myCPU.ReadData ;             //显示数据存储器读出的数据
        else if (sw_i[5:0]==6'b0000111) disp_data <= myCPU.datamem.Addr ;        //显示数据存储器访问的地址
        else if (sw_i[3]==1) disp_data <= -1 ;                                //显示-1
        else if (sw_i[4]==1) disp_data <= -1 ;                                //显示-1
        else disp_data <= myCPU.datamem.result;                               //显示默认的0xAA5555AA或者写入0xFFFF000C的值

    seg7x16 u_test(
        .clk(clk),
        .rstn(rstn),
        .disp_mode(0),
        .i_data(disp_data),
        .disp_seg_o(disp_seg_o),
        .disp_an_o(disp_an_o)
        );
        
    
endmodule
