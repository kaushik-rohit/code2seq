public int peek1() throws OtpErlangDecodeException {
        int i;
        try {
            i = super.buf[super.pos];
            if (i < 0) {
                i += 256;
            }

            return i;
        } catch (final Exception e) {
            throw new OtpErlangDecodeException("Cannot read from input stream");
        }
    }