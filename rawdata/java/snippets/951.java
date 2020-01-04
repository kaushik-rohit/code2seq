int append(ByteArraySegment data) {
        ensureAppendConditions();

        int actualLength = Math.min(data.getLength(), getAvailableLength());
        if (actualLength > 0) {
            this.contents.copyFrom(data, writePosition, actualLength);
            writePosition += actualLength;
        }

        return actualLength;
    }