@SuppressWarnings("unchecked")
	public static <T> Collection<T> removeAny(Collection<T> collection, T... elesRemoved) {
		collection.removeAll(newHashSet(elesRemoved));
		return collection;
	}