onbreak {quit -f}
onerror {quit -f}

vsim -t 1ps -lib xil_defaultlib immg_opt

do {wave.do}

view wave
view structure
view signals

do {immg.udo}

run -all

quit -force
