public static @Nonnull Number requirePositive(String name, Number value) {
        requireNonNull(name, value);
        requirePositive(name, value.intValue());
        return value;
    }