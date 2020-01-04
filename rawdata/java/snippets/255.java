public static <T> CompletableFuture<T> retry(
			final Supplier<CompletableFuture<T>> operation,
			final int retries,
			final Executor executor) {

		final CompletableFuture<T> resultFuture = new CompletableFuture<>();

		retryOperation(resultFuture, operation, retries, executor);

		return resultFuture;
	}