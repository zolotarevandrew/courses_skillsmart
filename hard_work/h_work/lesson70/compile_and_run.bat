nasm.exe -f win32 bubble_sort.asm -o out.obj 
golink /console /entry _main out.obj kernel32.dll
out.exe