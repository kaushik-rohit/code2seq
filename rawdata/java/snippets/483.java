@Override
    public void close() throws IOException {
        // Skip over the remaining bytes. Do not close the underlying InputStream.
        if (this.remaining > 0) {
            int toSkip = this.remaining;
            long skipped = skip(toSkip);
            if (skipped != toSkip) {
                throw new SerializationException(String.format("Read %d fewer byte(s) than expected only able to skip %d.", toSkip, skipped));
            }
        } else if (this.remaining < 0) {
            throw new SerializationException(String.format("Read more bytes than expected (%d).", -this.remaining));
        }
    }