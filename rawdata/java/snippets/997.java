public void cancelPendingTake() {
        CompletableFuture<Queue<T>> pending;
        synchronized (this.contents) {
            pending = this.pendingTake;
            this.pendingTake = null;
        }

        // Cancel any pending poll request.
        if (pending != null) {
            pending.cancel(true);
        }
    }