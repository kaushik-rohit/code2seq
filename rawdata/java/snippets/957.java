public UnixPath getName(int index) {
    if (path.isEmpty()) {
      return this;
    }
    try {
      return new UnixPath(permitEmptyComponents, getParts().get(index));
    } catch (IndexOutOfBoundsException e) {
      throw new IllegalArgumentException();
    }
  }