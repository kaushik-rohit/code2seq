public static ListValue of(Timestamp first, Timestamp... other) {
    return newBuilder().addValue(first, other).build();
  }