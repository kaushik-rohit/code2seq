public final long getBeUlong40(final int pos) {
        final int position = origin + pos;

        if (pos + 4 >= limit || pos < 0) throw new IllegalArgumentException("limit excceed: "
                                                                            + (pos < 0 ? pos : (pos + 4)));

        byte[] buf = buffer;
        return ((long) (0xff & buf[position + 4])) | ((long) (0xff & buf[position + 3]) << 8)
               | ((long) (0xff & buf[position + 2]) << 16) | ((long) (0xff & buf[position + 1]) << 24)
               | ((long) (0xff & buf[position]) << 32);
    }