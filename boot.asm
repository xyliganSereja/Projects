use16
; org 0x7C00
main:
    ; load program
    mov ah, 0x02        ; load sector
    mov al, 1           ; sectors count
    mov dl, 0x80        ; drive (0x80 = first hard drive)
    mov ch, 0           ; cylinder
    mov dh, 0           ; head 
    mov cl, 2           ; sector
    xor bx, bx
    mov es, bx
    mov bx, startbuf    ; buffer address
    int 0x13

    jmp start

    ; Magic bytes.    
    times ((0x200 - 2) - ($ - $$)) db 0x00
    dw 0xAA55

startbuf    equ 0x00007E00
dir         equ 0x00000500
dir_up      equ 0
dir_right   equ 1
dir_down    equ 2
dir_left    equ 3
head        equ 0x00000502
tail        equ 0x00000504
bodyx       equ 0x00000510
bodyy       equ 0x00000BC2

foodctr     equ 0x00000506
foodper     equ 45

arenaw      equ 45
arenah      equ 45
maxlen      equ 2025
pixel_size  equ 4
border      equ 4
startlen    equ 3

food_color  equ 0x9
bord_color  equ 0xF
snake_color equ 0x4



start:
    ; set mode 
    mov ax, 0x0013
    int 0x10

    ; todo fill zeros
    mov word [head], startlen
    mov word [tail], 1
    mov byte [dir], 1
    mov cx, 0
    mov dx, 0
    mov byte [foodctr], 1
   
    call draw_border
    jmp repeat


draw_pixel:
    push cx
    push dx

    mov ch, 0
    mov dh, 0

    mov ah, 0x0C
    lea cx, [border + pixel_size * ecx]
    lea dx, [border + pixel_size * edx]
    int 0x10
    inc cx
    int 0x10
    inc dx
    int 0x10
    dec cx
    int 0x10

    pop dx
    pop cx
    ret

get_pixel:
    push cx
    push dx

    mov ch, 0
    mov dh, 0

    mov ah, 0x0D
    lea cx, [border + pixel_size * ecx]
    lea dx, [border + pixel_size * edx]
    int 0x10

    pop dx
    pop cx
    ret

handle_press:
    mov ax, 0x0100
    int 0x16

    jz .ret

    mov ax, 0x0000
    int 0x16

    cmp ah, 0x48
    je .up
    
    cmp ah, 0x50
    je .down

    cmp ah, 0x4B
    je .left

    cmp ah, 0x4D
    je .right
    
    ret

.up:
    cmp byte [dir], dir_down
    je .ret
    mov byte [dir], dir_up
    ret
.down:
    cmp byte [dir], dir_up
    je .ret
    mov byte [dir], dir_down
    ret 
.left:
    cmp byte [dir], dir_right
    je .ret
    mov byte [dir], dir_left
    ret
.right:
    cmp byte [dir], dir_left
    je .ret
    mov byte [dir], dir_right
.ret:
    ret

draw_border:
    push cx
    push dx

    mov ah, 0x0C
    mov al, bord_color
    mov cx, 2
    mov dx, 2
    lea bp, [arenah * pixel_size + border]

.draw1:
    int 0x10
    inc dx
    cmp dx, bp
    jl .draw1


    dec dx
    lea bp, [arenaw * pixel_size + border]
.draw2:
    int 0x10
    inc cx
    cmp cx, bp
    jl .draw2
    
    dec cx
.draw3:
    int 0x10
    dec dx
    cmp dx, 1
    jg .draw3
    
    inc dx
.draw4:
    int 0x10
    dec cx
    cmp cx, 1
    jg .draw4

    pop dx
    pop cx
    ret


next_color:
    inc al
    cmp al, 0x10
    jl .ret
    mov al, 1
.ret:
    ret

move:
    push cx
    push dx

    mov bp, word [head]
    inc bp
    cmp bp, maxlen
    jl .skip
    sub bp, maxlen
.skip:
    mov word [head], bp
    mov byte [bp + bodyx], cl
    mov byte [bp + bodyy], dl
    call get_pixel
    cmp al, snake_color
    je start
    cmp al, food_color
    je .plus_len
    mov al, snake_color
    call draw_pixel

    mov bp, word [tail]
    mov cl, byte [bp + bodyx]
    mov dl, byte [bp + bodyy]
    mov al, 0x00
    call draw_pixel

    inc bp
    cmp bp, maxlen
    jl .skip2
    sub bp, maxlen
.skip2:
    mov word [tail], bp
    jmp .ret

.plus_len:
    mov al, snake_color
    call draw_pixel
.ret:
    pop dx
    pop cx
    ret



repeat:
    call handle_press
    
    mov ah, byte [dir]

    cmp ah, dir_up
    je .up
    
    cmp ah, dir_down
    je .down

    cmp ah, dir_left
    je .left

    cmp ah, dir_right
    je .right

    jmp repeat
.up:
    dec dl
    jge .move
    add dl, arenah 
    jmp .move
.down:
    inc dl
    cmp dl, arenah
    jl .move
    sub dl, arenah
    jmp .move
.left:
    dec cl
    jge .move
    add cl, arenaw
    jmp .move
.right:
    inc cl
    cmp cl, arenaw
    jl .move
    sub cl, arenaw   

.move:
    call move

    call wait_

    call food
    jmp repeat

wait_:
    push cx
    push dx
    mov ax, 0x8600
    mov cx, 0x0001
    mov dx, 0x86A0
    int 0x15
    pop dx
    pop cx
    ret

food:
    push cx
    push dx

    dec byte [foodctr]
    jnz .ret
    mov byte [foodctr], foodper
    mov ebp, arenaw
    div ebp
    mov cl, dl

    mov ebp, arenah
    div ebp

    call get_pixel
    cmp al, snake_color
    je .ret
    mov al, food_color
    call draw_pixel

.ret:
    pop dx
    pop cx
    ret
