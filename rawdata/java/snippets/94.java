public static ByteBuf copyLong(long... values) {
        if (values == null || values.length == 0) {
            return EMPTY_BUFFER;
        }
        ByteBuf buffer = buffer(values.length * 8);
        for (long v: values) {
            buffer.writeLong(v);
        }
        return buffer;
    }