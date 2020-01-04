public static <IN, OUT> CompletableFuture<OUT> handleAsyncIfNotDone(
		CompletableFuture<IN> completableFuture,
		Executor executor,
		BiFunction<? super IN, Throwable, ? extends OUT> handler) {
		return completableFuture.isDone() ?
			completableFuture.handle(handler) :
			completableFuture.handleAsync(handler, executor);
	}