public static <T> T getFirst(Collection<T> collection) {
		if (isEmpty(collection)) {
			return null;
		}
		if (collection instanceof List) {
			return ((List<T>) collection).get(0);
		}
		return collection.iterator().next();
	}