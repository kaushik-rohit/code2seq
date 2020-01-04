static <T> List<T> list(T... elements) {
    return new ArrayList<>(Arrays.asList(elements));
  }