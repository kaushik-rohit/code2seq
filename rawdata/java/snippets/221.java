CompletableFuture<ClientConnection> getConnection() throws SegmentSealedException {
        if (state.isClosed()) {
            throw new IllegalStateException("SegmentOutputStream is already closed", state.getException());
        }
        if (state.isAlreadySealed()) {
            throw new SegmentSealedException(this.segmentName);
        }
        if (state.getConnection() == null) {
            reconnect();
        }
        CompletableFuture<ClientConnection> future =  new CompletableFuture<>();
        state.setupConnection.register(future);
        return future;
    }