Header readHeader(@NonNull InputStream input) throws IOException {
        byte version = (byte) input.read();
        int keyLength = BitConverter.readInt(input);
        int valueLength = BitConverter.readInt(input);
        long entryVersion = BitConverter.readLong(input);
        validateHeader(keyLength, valueLength);
        return new Header(version, keyLength, valueLength, entryVersion);
    }