private int addComponent0(boolean increaseWriterIndex, int cIndex, ByteBuf buffer) {
        assert buffer != null;
        boolean wasAdded = false;
        try {
            checkComponentIndex(cIndex);

            // No need to consolidate - just add a component to the list.
            Component c = newComponent(buffer, 0);
            int readableBytes = c.length();

            addComp(cIndex, c);
            wasAdded = true;
            if (readableBytes > 0 && cIndex < componentCount - 1) {
                updateComponentOffsets(cIndex);
            } else if (cIndex > 0) {
                c.reposition(components[cIndex - 1].endOffset);
            }
            if (increaseWriterIndex) {
                writerIndex += readableBytes;
            }
            return cIndex;
        } finally {
            if (!wasAdded) {
                buffer.release();
            }
        }
    }