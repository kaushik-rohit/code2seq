synchronized String registerHandle(AbstractAppHandle handle) {
    String secret = createSecret();
    secretToPendingApps.put(secret, handle);
    return secret;
  }