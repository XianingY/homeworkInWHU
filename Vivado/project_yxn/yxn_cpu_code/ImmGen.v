
module ImmGen(
        input [31:0] instr, 
        input   Reset,
        output reg [31:0] extend 
    );
always@(instr or Reset/*or negedge Reset*/)
    begin
        if(!Reset)
            extend=0;
        else begin
        case (instr[6:0])
            7'b0000011://加载指令
            begin
                extend={instr[31]?20'hfffff:20'h00000,instr[31:20]};
            end
            7'b0010011://i型指令中的立即数操作指令
            begin
                if(instr[14:12]==3'b001||instr[14:12]==3'b101)    //移位指令立即数不超过12位
                extend={instr[31]?27'hfffffff:27'h0000000,instr[24:20]};
                else
                extend={instr[31]?20'hfffff:20'h00000,instr[31:20]};
            end
            7'b1100111://jalr
            begin
                extend={instr[31]?20'hfffff:20'h00000,instr[31:20]};
            end
            7'b0100011://s型指令
            begin
                extend[11:0] = {instr[31:25],instr[11:7]};
                extend[31:12] = instr[31]?20'hfffff:20'h00000;
            end
            7'b1100011://sb型指令
            begin
                extend[11:0] = {instr[31],instr[7],instr[30:25],instr[11:8]};
                extend[31:12] = instr[31]?20'hfffff:20'h00000;
            end
            7'b1101111://uj型，jal
            begin
                extend[19:0]={instr[31],instr[19:12],instr[20],instr[30:21]};
                extend[31:20] = instr[31]?12'hfff:12'h000;
            end
            7'b0110111://u型,lui
            begin
                extend[31:12] = instr[31:12];
                extend[11:0] = 12'h0000;
            end
            7'b0010111://auipc
            begin
                extend[31:12] = instr[31:12];
                extend[11:0] = 12'h0000;
            end
            default:extend=0;
    endcase
    end
    end
endmodule
