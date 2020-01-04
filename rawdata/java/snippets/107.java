public static int readInt(InputStream source) throws IOException {
        int b1 = source.read();
        int b2 = source.read();
        int b3 = source.read();
        int b4 = source.read();
        if ((b1 | b2 | b3 | b4) < 0) {
            throw new EOFException();
        } else {
            return (b1 << 24) + (b2 << 16) + (b3 << 8) + b4;
        }
    }