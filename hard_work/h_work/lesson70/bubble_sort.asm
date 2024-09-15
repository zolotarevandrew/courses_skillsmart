section .data
    hStdInput  dd 0                
    hStdOutput dd 0                
	
    nElementsMsg db 'Enter elements to sort without comma eg 123456 - means 1,2,3,4,5,6: ', 13, 10, 0
    nElementsLen equ $ - nElementsMsg 
	
    printBytesWritten dd 0                     

    inputBuffer  db 256 dup(0)       
    charsRead    dd 0   
    loopRead     dd 0	
    outputBuffer dd 64 dup(0)
	outputBufferChars db 64 dup(0)
	lengthBuffer db 1 dup(0)   
	loopBuffer db 1 dup(0)

section .text
    global _main
    extern _GetStdHandle@4
    extern _WriteConsoleA@20
    extern _ReadConsoleA@20
    extern _ExitProcess@4
	extern _Sleep@4                        

_main:
    push -11                  ; STD_OUTPUT_HANDLE (-11)
    call _GetStdHandle@4          
    mov [hStdOutput], eax  

    push -10                  ; STD_INPUT_HANDLE (-11)
    call _GetStdHandle@4          
    mov [hStdInput], eax
             
    push dword printBytesWritten    
    push dword nElementsLen         
    push dword nElementsMsg         
	
    call print_string                    

    push dword 255                 
    push dword inputBuffer                

    call read_string

	push dword [charsRead]      
    push dword inputBuffer      
    call loop_through_buffer    

	
	call bubble_sort
	
	call convert_outputBuffer_to_chars

	push dword printBytesWritten    
    push dword [charsRead]      
    push dword outputBufferChars
	call print_string

    push 0                       
    call _ExitProcess@4    

print_string:
    push ebp                    ; Save the base pointer
    mov ebp, esp                ; Set up the new stack frame

    push dword 0                ; Reserved argument (NULL)
    push dword [ebp+16]         ; Pointer to bytes_written
    push dword [ebp+12]         ; Length of the message
    push dword [ebp+8]          ; Pointer to the message
    push dword [hStdOutput]     ; Console handle (from global variable)

    call _WriteConsoleA@20      ; Call WriteConsoleA (stdcall cleans up stack)

    mov esp, ebp                ; Restore the stack pointer
    pop ebp                     ; Restore the base pointer
    ret                         ; Return to the caller
	
read_string:
    push ebp                    ; Save the base pointer
    mov ebp, esp                ; Set up the new stack frame

    push dword 0                ; lpReserved (NULL)
    lea eax, [charsRead]      ; Load effective address
    push eax
	
    push dword [ebp + 12]       ; Number of characters to read
    push dword [ebp + 8]        ; lpBuffer (address of the buffer)
    push dword [hStdInput]      ; hConsoleInput (handle to standard input)

    call _ReadConsoleA@20       ; Call ReadConsoleA
	
	mov eax, [charsRead]        
    cmp eax, 2                  ; Ensure at least two characters were read
    jl no_trim
	
	;Wtf windows functions... i like it
	
	mov esi, [ebp + 8]          ; Get the input buffer pointer
    movzx edx, byte [esi + eax - 2] ; Check the second last character
    cmp dl, 13                  ; Is it a carriage return (`\r` = 13)?
    jne no_trim 

	movzx edx, byte [esi + eax - 1] ; Check the last character
    cmp dl, 10                  ; Is it a newline (`\n` = 10)?
    jne no_trim                 ; If not, skip trimming

    ; If both '\r' and '\n' are found, reduce charsRead by 2
    sub eax, 2                  ; Decrease charsRead by 2
    mov [charsRead], eax        ; Store the updated value in charsRead

    pop ebp                     ; Restore the base pointer
    ret                         ; Return to the caller

no_trim:
    pop ebp                     ; Restore the base pointer
    ret                         ; Return to the caller

loop_through_buffer:
    push ebp                    ; Save the base pointer
    mov ebp, esp                ; Set up the new stack frame

    xor ecx, ecx                
    mov esi, [ebp+8]            
	mov edi, outputBuffer

loop_start:
    cmp ecx, [ebp+12]           ; Compare index with charsRead (number of characters)
    jge loop_end                ; If ecx >= charsRead, jump to the end of the loop
	
	movzx eax, byte [esi + ecx]  ; Get the character at inputBuffer[ecx] into eax
	sub eax, '0'                ; Convert ASCII character to integer (subtract '0' which is 48)
    mov [edi + ecx * 4], eax    
    
    inc ecx                      
    jmp loop_start               

loop_end:
    mov esp, ebp                ; Restore the stack pointer
    pop ebp                     ; Restore the base pointer
    ret                         ; Return to the caller
	
	
convert_charsRead_to_string:
    push ebp                    ; Save the base pointer
    mov ebp, esp                ; Set up the new stack frame

    mov eax, [charsRead]        
    add eax, '0'                
    mov [lengthBuffer], al      

    mov esp, ebp                ; Restore the stack pointer
    pop ebp                     ; Restore the base pointer
    ret                         ; Return to the caller
	
convert_loopRead_to_string:
    push ebp                    ; Save the base pointer
    mov ebp, esp                ; Set up the new stack frame

    mov eax, [loopRead]        ; Load the value of charsRead into eax
    add eax, '0'                ; Convert the single-digit number to its ASCII equivalent
    mov [loopBuffer], al      ; Store the ASCII character in the lengthBuffer

    mov esp, ebp                ; Restore the stack pointer
    pop ebp                     ; Restore the base pointer
    ret                         ; Return to the caller
	
convert_outputBuffer_to_chars:
    push ebp                    ; Save the base pointer
    mov ebp, esp                ; Set up the new stack frame

    xor ecx, ecx                ; Clear ecx (index for looping)
    mov esi, outputBuffer       ; Load the address of outputBuffer into esi
    mov edi, outputBufferChars  ; Load the address of outputBufferChars into edi

convert_loop:
    cmp ecx, [charsRead]        ; Compare ecx with the number of elements (charsRead)
    jge convert_end             ; If ecx >= charsRead, we are done

    mov eax, [esi + ecx * 4]    ; Get the integer from outputBuffer[ecx]
    add eax, '0'                ; Convert the integer to its ASCII equivalent
    mov [edi + ecx], al         ; Store the ASCII character in outputBufferChars[ecx]

    inc ecx                     ; Increment the index
    jmp convert_loop            ; Repeat the loop

convert_end:
    mov esp, ebp                
    pop ebp                     
    ret                         
	
swap_elements_if_needed:
    push ebp
    mov ebp, esp

    mov eax, [ebp+8]         ; index

    mov esi, outputBuffer


    mov edx, [esi + eax*4]       ; edx = outputBuffer[index]
    mov ecx, [esi + eax*4 + 4]   ; ecx = outputBuffer[index + 1]

    ; If outputBuffer[index] <= outputBuffer[index+1], skip
    cmp edx, ecx
    jle skip_swap                

    ; Swap
    mov [esi + eax*4], ecx       
    mov [esi + eax*4 + 4], edx   

skip_swap:
    mov esp, ebp            
    pop ebp                 
    ret                     
	

bubble_sort:
    push ebp
    mov ebp, esp

    mov esi, outputBuffer

 
    mov ebx, [charsRead]   ; number of elements       
    dec ebx                ; number of elements  = n - 1 for indexing	

outer_loop:
    xor edi, edi                 ; i = 0

inner_loop:
    cmp edi, ebx                 ; if i >= charsRead - 1
    jge end_inner_loop           

    push edi                     ; Push i
    call swap_elements_if_needed  
    add esp, 4                   ; clean stack

    inc edi                      ; i++
    jmp inner_loop               ; repeat inner loop

end_inner_loop:
    dec ebx                      ; charsRead--
    cmp ebx, 0                   ; If charsRead == 0 stop
    jg outer_loop                ; else repeat

    mov esp, ebp
    pop ebp
    ret