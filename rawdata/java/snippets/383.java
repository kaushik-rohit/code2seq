@Override
    @SuppressWarnings({"unchecked"})
    public <T> T[] toArray(final T[] destination) {
        requireNonNull(destination, ILLEGAL_DESTINATION_ARRAY);

        Supplier<T[]> copyRingBuffer = () -> {
            if (size == 0) {
                return destination;
            }
            T[] result = destination;
            if (destination.length < size) {
                result = (T[]) newInstance(result.getClass().getComponentType(), size);
            }
            if (headIndex <= tailIndex) {
                System.arraycopy(ringBuffer, headIndex, result, 0, size);
            } else {
                int toTheEnd = ringBuffer.length - headIndex;
                System.arraycopy(ringBuffer, headIndex, result, 0, toTheEnd);
                System.arraycopy(ringBuffer, 0, result, toTheEnd, tailIndex + 1);
            }
            return result;
        };
        return readConcurrentlyWithoutSpin(copyRingBuffer);
    }