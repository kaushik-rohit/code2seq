public static <T> CompletableFuture<T> exceptionallyComposeExpecting(CompletableFuture<T> future, Predicate<Throwable> isExpected,
                                                                         Supplier<CompletableFuture<T>> exceptionFutureSupplier) {
        return exceptionallyCompose(future,
                ex -> {
                    if (isExpected.test(Exceptions.unwrap(ex))) {
                        return exceptionFutureSupplier.get();
                    } else {
                        return Futures.failedFuture(ex);
                    }
                });
    }