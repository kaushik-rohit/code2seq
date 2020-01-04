static byte[] shortToBytes(short value) {
        byte[] bytes = new byte[2];
        if (PlatformDependent.BIG_ENDIAN_NATIVE_ORDER) {
            bytes[1] = (byte) ((value >> 8) & 0xff);
            bytes[0] = (byte) (value & 0xff);
        } else {
            bytes[0] = (byte) ((value >> 8) & 0xff);
            bytes[1] = (byte) (value & 0xff);
        }
        return bytes;
    }