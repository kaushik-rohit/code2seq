public static <T> Set<T> wrapSet(final T source) {
        val list = new LinkedHashSet<T>();
        if (source != null) {
            list.add(source);
        }
        return list;
    }