public static <K, V> HashMap<K, V> toMap(Iterable<Entry<K, V>> entryIter) {
		final HashMap<K, V> map = new HashMap<K, V>();
		if (isNotEmpty(entryIter)) {
			for (Entry<K, V> entry : entryIter) {
				map.put(entry.getKey(), entry.getValue());
			}
		}
		return map;
	}