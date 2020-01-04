public static OperationInvoker apply(OperationInvoker invoker, long timeToLive) {
		if (timeToLive > 0) {
			return new CachingOperationInvoker(invoker, timeToLive);
		}
		return invoker;
	}