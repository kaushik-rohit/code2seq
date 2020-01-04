@Nullable
  public Date getDate(@Nonnull String field) {
    return ((Timestamp) get(field)).toDate();
  }