public static <T> boolean await(CompletableFuture<T> f, long timeout) {
        Exceptions.handleInterrupted(() -> {
            try {
                f.get(timeout, TimeUnit.MILLISECONDS);
            } catch (TimeoutException | ExecutionException e) {
                // Not handled here.
            }
        });
        return isSuccessful(f);
    }