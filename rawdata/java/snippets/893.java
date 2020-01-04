public static Object callConstructor(final Class<?> cls, final Object... args) {
    return callConstructor(cls, getTypes(args), args);
  }