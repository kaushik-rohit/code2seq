private static ByteBuf append(ByteBufAllocator allocator, boolean useDirect,
            X509Certificate cert, int count, ByteBuf pem) throws CertificateEncodingException {

        ByteBuf encoded = Unpooled.wrappedBuffer(cert.getEncoded());
        try {
            ByteBuf base64 = SslUtils.toBase64(allocator, encoded);
            try {
                if (pem == null) {
                    // We try to approximate the buffer's initial size. The sizes of
                    // certificates can vary a lot so it'll be off a bit depending
                    // on the number of elements in the array (count argument).
                    pem = newBuffer(allocator, useDirect,
                            (BEGIN_CERT.length + base64.readableBytes() + END_CERT.length) * count);
                }

                pem.writeBytes(BEGIN_CERT);
                pem.writeBytes(base64);
                pem.writeBytes(END_CERT);
            } finally {
                base64.release();
            }
        } finally {
            encoded.release();
        }

        return pem;
    }