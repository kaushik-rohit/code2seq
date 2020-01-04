public static <T> Key<T> keyWithDefault(String name, T defaultValue) {
    return new Key<>(name, defaultValue);
  }