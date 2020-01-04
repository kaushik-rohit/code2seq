@GetMapping("/user")
  public ResponseEntity<User> getUser(
      @VersionApi int version, //<1>
      @RequestParam("id") String id) {
    throw new UnsupportedOperationException();
  }