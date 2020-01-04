public static <T> T getFirst(Iterable<T> iterable) {
		if (null != iterable) {
			return getFirst(iterable.iterator());
		}
		return null;
	}