main:	addi x5, x0, 2
        sw x5 0(x0)
        
	addi x6, x0, 1
        addi x6 x6 1
        
        
        lw x10 0(x0)
        addi x10 x10 1
        
         
		addi x7, x0, 0			
		addi x8, x0, 0
		beq  x5, x6, br1
		addi x8, x8, 1			
		addi x9, x9, 1
		jal  x0, end

br1:	addi x7, x7, 1			
		jal  x0, end
		addi x8, x8, 1			
		addi x9, x9, 1
        addi x8 x8 1

end:	addi x7, x7, 1