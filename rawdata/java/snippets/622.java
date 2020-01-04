public static <K, V> Map<K, V> wrap(final Multimap<K, V> source) {
        if (source != null && !source.isEmpty()) {
            val inner = source.asMap();
            val map = new HashMap<Object, Object>();
            inner.forEach((k, v) -> map.put(k, wrap(v)));
            return (Map) map;
        }
        return new HashMap<>(0);
    }