@RequirePOST
    public HttpResponse doStop() {
        lock.writeLock().lock(); // need write lock as interrupt will change the field
        try {
            if (executable != null) {
                getParentOf(executable).getOwnerTask().checkAbortPermission();
                interrupt();
            }
        } finally {
            lock.writeLock().unlock();
        }
        return HttpResponses.forwardToPreviousPage();
    }