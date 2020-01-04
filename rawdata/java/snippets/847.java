protected final ByteBuf composeIntoComposite(ByteBufAllocator alloc, ByteBuf cumulation, ByteBuf next) {
        // Create a composite buffer to accumulate this pair and potentially all the buffers
        // in the queue. Using +2 as we have already dequeued current and next.
        CompositeByteBuf composite = alloc.compositeBuffer(size() + 2);
        try {
            composite.addComponent(true, cumulation);
            composite.addComponent(true, next);
        } catch (Throwable cause) {
            composite.release();
            safeRelease(next);
            throwException(cause);
        }
        return composite;
    }