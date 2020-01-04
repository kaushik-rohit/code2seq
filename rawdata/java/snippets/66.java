@Override
    public CompletableFuture<Void> execute(CommitEvent event) {
        String scope = event.getScope();
        String stream = event.getStream();
        OperationContext context = streamMetadataStore.createContext(scope, stream);
        log.debug("Attempting to commit available transactions on stream {}/{}", event.getScope(), event.getStream());

        CompletableFuture<Void> future = new CompletableFuture<>();

        // Note: we will ignore the epoch in the event. It has been deprecated. 
        // The logic now finds the smallest epoch with transactions and commits them.
        tryCommitTransactions(scope, stream, context)
                .whenComplete((r, e) -> {
                    if (e != null) {
                        Throwable cause = Exceptions.unwrap(e);
                        // for operation not allowed, we will report the event
                        if (cause instanceof StoreException.OperationNotAllowedException) {
                            log.debug("Cannot commit transaction on stream {}/{}. Postponing", scope, stream);
                        } else {
                            log.error("Exception while attempting to commit transaction on stream {}/{}", scope, stream, e);
                        }
                        future.completeExceptionally(cause);
                    } else {
                        if (r >= 0) {
                            log.debug("Successfully committed transactions on epoch {} on stream {}/{}", r, scope, stream);
                        } else {
                            log.debug("No transactions found in committing state on stream {}/{}", r, scope, stream);
                        }
                        if (processedEvents != null) {
                            try {
                                processedEvents.offer(event);
                            } catch (Exception ex) {
                                // ignore, this processed events is only added for enabling unit testing this class
                            }
                        }
                        future.complete(null);
                    }
                });

        return future;
    }