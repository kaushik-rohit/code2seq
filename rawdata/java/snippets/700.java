@SuppressWarnings("WeakerAccess")
  public CreateClusterRequest setStorageType(@Nonnull StorageType storageType) {
    Preconditions.checkNotNull(storageType);
    Preconditions.checkArgument(
        storageType != StorageType.UNRECOGNIZED, "StorageType can't be UNRECOGNIZED");

    proto.getClusterBuilder().setDefaultStorageType(storageType.toProto());
    return this;
  }