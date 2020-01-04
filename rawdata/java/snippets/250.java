static void requireState(boolean expression, String template, @Nullable Object... args) {
    if (!expression) {
      throw new IllegalStateException(String.format(template, args));
    }
  }