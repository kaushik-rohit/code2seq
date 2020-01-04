public void append(byte[] utf8, int start, int len) {
        setCapacity(length + len, true);
        System.arraycopy(utf8, start, bytes, length, len);
        length += len;
    }