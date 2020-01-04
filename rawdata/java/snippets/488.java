public final int getInt32(final int pos) {
        final int position = origin + pos;

        if (pos + 3 >= limit || pos < 0) throw new IllegalArgumentException("limit excceed: "
                                                                            + (pos < 0 ? pos : (pos + 3)));

        byte[] buf = buffer;
        return (0xff & buf[position]) | ((0xff & buf[position + 1]) << 8) | ((0xff & buf[position + 2]) << 16)
               | ((buf[position + 3]) << 24);
    }