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
        //��Ƶ
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

    //��ʾ������1��ʾPC������2��ʾ�Ĵ�����Ĭ����ʾ�˿����
    always @ (posedge clkdiv)
        if(sw_i[6]) disp_data <= myCPU.datamem.ram[sw_i[5:0]] ;     //��ʾ�ڴ�
        else if (sw_i[5]) disp_data <= myCPU.regfile.rf[sw_i[4:0]] ;//��ʾ�Ĵ���
        else if (sw_i[5:0]==6'b0000000) disp_data <= myCPU.datamem.result; //��ʾĬ�ϵ�0xAA5555AA����д��0xFFFF000C��ֵ
        else if (sw_i[5:0]==6'b0000001) disp_data <= myCPU.PC;             //��ʾָ�����
        else if (sw_i[5:0]==6'b0000010) disp_data <= myCPU.PC<<2;          //��ʾָ���ַ
        else if (sw_i[5:0]==6'b0000011) disp_data <= myCPU.instr;          //��ʾָ��
        else if (sw_i[5:0]==6'b0000100) disp_data <= myCPU.datamem.Addr ;  //��ʾ�洢����ַ
        else if (sw_i[5:0]==6'b0000101) disp_data <= myCPU.datamem.WriteData ;  //��ʾд��洢��������
        else if (sw_i[5:0]==6'b0000110) disp_data <= myCPU.ReadData ;             //��ʾ���ݴ洢������������
        else if (sw_i[5:0]==6'b0000111) disp_data <= myCPU.datamem.Addr ;        //��ʾ���ݴ洢�����ʵĵ�ַ
        else if (sw_i[3]==1) disp_data <= -1 ;                                //��ʾ-1
        else if (sw_i[4]==1) disp_data <= -1 ;                                //��ʾ-1
        else disp_data <= myCPU.datamem.result;                               //��ʾĬ�ϵ�0xAA5555AA����д��0xFFFF000C��ֵ

    seg7x16 u_test(
        .clk(clk),
        .rstn(rstn),
        .disp_mode(0),
        .i_data(disp_data),
        .disp_seg_o(disp_seg_o),
        .disp_an_o(disp_an_o)
        );
        
    
endmodule
