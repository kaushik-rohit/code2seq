public static <T> T noNullElseGet(@NonNull Supplier<T> s1, @NonNull Supplier<T> s2) {
        T t1 = s1.get();
        if (t1 != null) {
            return t1;
        }
        return s2.get();
    }