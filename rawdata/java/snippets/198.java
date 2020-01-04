@SuppressWarnings("WeakerAccess")
  public UpdateAppProfileRequest setDescription(@Nonnull String description) {
    Preconditions.checkNotNull(description);

    proto.getAppProfileBuilder().setDescription(description);
    updateFieldMask(com.google.bigtable.admin.v2.AppProfile.DESCRIPTION_FIELD_NUMBER);
    return this;
  }