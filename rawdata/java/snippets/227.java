@SuppressWarnings("resource")
    void send(final OtpErlangPid from, final String dest,
            final OtpErlangObject msg) throws IOException {
        // encode and send the message
        sendBuf(from, dest, new OtpOutputStream(msg));
    }