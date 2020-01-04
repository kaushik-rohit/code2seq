public CompletableFuture<PingTxnStatus> pingTxn(final String scope,
                                                    final String stream,
                                                    final UUID txId,
                                                    final long lease,
                                                    final OperationContext contextOpt) {
        final OperationContext context = getNonNullOperationContext(scope, stream, contextOpt);
        return pingTxnBody(scope, stream, txId, lease, context);
    }