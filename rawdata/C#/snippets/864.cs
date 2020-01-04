public int GetCallInstructionLength()
        {
            // --- We intentionally avoid using ReadMemory() directly
            // --- So that we can prevent false memory touching.
            var opCode = _memoryDevice.Read(_registers.PC);

            // --- CALL instruction
            if (opCode == 0xCD) return 3;

            // --- Call instruction with condition
            if ((opCode & 0xC7) == 0xC4) return 3;

            // --- Check for RST instructions
            if ((opCode & 0xC7) == 0xC7) return 1;

            // --- Check for HALT instruction
            if (opCode  == 0x76) return 1;

            // --- Check for extended instruction prefix
            if (opCode != 0xED) return 0;

            // --- Check for I/O and block transfer instructions
            opCode = _memoryDevice.Read((ushort) (_registers.PC + 1));
            return ((opCode & 0xB4) == 0xB0) ? 2 : 0;
        }