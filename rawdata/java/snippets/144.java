public boolean setSessionIdContext(byte[] sidCtx) {
        Lock writerLock = context.ctxLock.writeLock();
        writerLock.lock();
        try {
            return SSLContext.setSessionIdContext(context.ctx, sidCtx);
        } finally {
            writerLock.unlock();
        }
    }