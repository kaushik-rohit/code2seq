static FirestoreException serverRejected(Status status, String message, Object... params) {
    return new FirestoreException(String.format(message, params), status);
  }