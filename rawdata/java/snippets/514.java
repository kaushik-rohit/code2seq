private boolean checkFreeSlotAt(final long sequence) {
        final long wrapPoint = sequence - bufferSize;
        if (wrapPoint > flushSequence.get()) { // 刚好追上一轮
            return false;
        } else {
            return true;
        }
    }