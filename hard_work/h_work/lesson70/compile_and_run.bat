nasm.exe -f win32 output_array.asm -o out.obj 
golink /console /entry _main out.obj kernel32.dll
out.exe