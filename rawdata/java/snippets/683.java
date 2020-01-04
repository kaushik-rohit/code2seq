public static <T> Collection<T> filterOut(Collection<T> collection, Collection<T> toExclude) {
        return collection.stream().filter(o -> !toExclude.contains(o)).collect(Collectors.toList());
    }