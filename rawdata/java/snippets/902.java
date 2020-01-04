private void readValues()
            throws IOException
    {
        lastReadInputCheckpoint = input.getCheckpoint();

        int control = input.read();
        if (control == -1) {
            throw new OrcCorruptionException(input.getOrcDataSourceId(), "Read past end of RLE integer");
        }

        if (control < 0x80) {
            numLiterals = control + MIN_REPEAT_SIZE;
            used = 0;
            repeat = true;
            delta = input.read();
            if (delta == -1) {
                throw new OrcCorruptionException(input.getOrcDataSourceId(), "End of stream in RLE Integer");
            }

            // convert from 0 to 255 to -128 to 127 by converting to a signed byte
            // noinspection SillyAssignment
            delta = (byte) delta;
            literals[0] = LongDecode.readVInt(signed, input);
        }
        else {
            numLiterals = 0x100 - control;
            used = 0;
            repeat = false;
            for (int i = 0; i < numLiterals; ++i) {
                literals[i] = LongDecode.readVInt(signed, input);
            }
        }
    }