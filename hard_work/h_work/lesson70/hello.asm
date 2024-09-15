section .data
    hello db 'Hello, World!', 0

section .text
    global _main                
    extern _ExitProcess@4        
    extern _WriteConsoleA@20     
    extern _GetStdHandle@4       

_main:
    push -11                     ; STD_OUTPUT_HANDLE (-11)
    call _GetStdHandle@4          
    mov ebx, eax                 

    push 0                       
    push 13                      
    push hello                   
    push ebx                     
    call _WriteConsoleA@20        


    push 0                       
    call _ExitProcess@4           