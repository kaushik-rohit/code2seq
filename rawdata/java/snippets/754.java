public CompletableFuture<Void> retention(final String scope, final String stream, final RetentionPolicy policy,
                                             final long recordingTime, final OperationContext contextOpt, final String delegationToken) {
        Preconditions.checkNotNull(policy);
        final OperationContext context = contextOpt == null ? streamMetadataStore.createContext(scope, stream) : contextOpt;
        final long requestId = requestTracker.getRequestIdFor("truncateStream", scope, stream);

        return streamMetadataStore.getRetentionSet(scope, stream, context, executor)
                .thenCompose(retentionSet -> {
                    StreamCutReferenceRecord latestCut = retentionSet.getLatest();
                    
                    return generateStreamCutIfRequired(scope, stream, latestCut, recordingTime, context, delegationToken)
                            .thenCompose(newRecord -> truncate(scope, stream, policy, context, retentionSet, newRecord, recordingTime, requestId));
                })
                .thenAccept(x -> StreamMetrics.reportRetentionEvent(scope, stream));

    }