public static void checkNotNull(Object o, String message, Object... args) {
        if (o == null) {
            throwStateEx(message, args);
        }
    }