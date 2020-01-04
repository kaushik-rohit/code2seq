public static <T> CompletableFuture<T> supplyAsync(SupplierWithException<T, ?> supplier, Executor executor) {
		return CompletableFuture.supplyAsync(
			() -> {
				try {
					return supplier.get();
				} catch (Throwable e) {
					throw new CompletionException(e);
				}
			},
			executor);
	}