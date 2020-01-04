public static <T> Publisher<T> fromCompletableFuture(Supplier<CompletableFuture<T>> futureSupplier) {
        return new CompletableFuturePublisher<>(futureSupplier);
    }