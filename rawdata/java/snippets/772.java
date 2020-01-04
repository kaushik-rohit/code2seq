private static Class<?>[] getTypes(final Object... args) {
    final Class<?>[] argTypes = new Class<?>[args.length];
    for (int i = 0; i < argTypes.length; i++) {
      argTypes[i] = args[i].getClass();
    }
    return argTypes;
  }