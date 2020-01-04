public static ByteBuffer getDirectByteBuffer(DirectBuffer directBuffer) {
        return directBuffer.byteBuffer() == null
                        ? ByteBuffer.allocateDirect(directBuffer.capacity()).put(directBuffer.byteArray())
                        : directBuffer.byteBuffer();
    }