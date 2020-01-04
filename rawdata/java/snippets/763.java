@Override
	public Iterable<Map.Entry<K, V>> entries() {
		return Collections.unmodifiableSet(state.entrySet());
	}