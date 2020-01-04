public static boolean varyMatches(
      Response cachedResponse, Headers cachedRequest, Request newRequest) {
    for (String field : varyFields(cachedResponse)) {
      if (!Objects.equals(cachedRequest.values(field), newRequest.headers(field))) return false;
    }
    return true;
  }