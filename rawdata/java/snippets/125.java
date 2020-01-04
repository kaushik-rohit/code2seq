public static <T> CompletableFuture<T> futureWithTimeout(Duration timeout, ScheduledExecutorService executorService) {
        return futureWithTimeout(timeout, null, executorService);
    }