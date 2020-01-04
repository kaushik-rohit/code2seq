public static int getVIntSize(long i) {
        if (i >= -112 && i <= 127) {
            return 1;
        }

        if (i < 0) {
            i ^= -1L; // take one's complement'
        }
        // find the number of bytes with non-leading zeros
        int dataBits = Long.SIZE - Long.numberOfLeadingZeros(i);
        // find the number of data bytes + length byte
        return (dataBits + 7) / 8 + 1;
    }