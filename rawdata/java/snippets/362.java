public static StorageLevel create(
    boolean useDisk,
    boolean useMemory,
    boolean useOffHeap,
    boolean deserialized,
    int replication) {
    return StorageLevel.apply(useDisk, useMemory, useOffHeap, deserialized, replication);
  }