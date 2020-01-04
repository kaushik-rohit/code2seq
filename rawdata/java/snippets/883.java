public static URI authorityToUri(String authority) {
    Preconditions.checkNotNull(authority, "authority");
    URI uri;
    try {
      uri = new URI(null, authority, null, null, null);
    } catch (URISyntaxException ex) {
      throw new IllegalArgumentException("Invalid authority: " + authority, ex);
    }
    return uri;
  }