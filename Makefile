all: flp
	qemu-system-x86_64 -hda boot.img

flp:
	nasm -f elf32 -g3 -F dwarf boot.asm -o boot.o
	ld -Ttext=0x7c00 -melf_i386 boot.o -o boot.elf
	objcopy -O binary boot.elf boot.img

gdb: flp
	qemu-system-i386 -s -S -hda boot.img


run-gdb:
	gdb boot.elf \
        -ex 'target remote localhost:1234' \
        -ex 'layout src' \
        -ex 'layout regs'

clean:
	rm -f *.bin *.img *.flp *.iso *.o *.elf
