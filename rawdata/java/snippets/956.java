public static SnapshotInfo of(SnapshotId snapshotId, DiskId source) {
    return newBuilder(snapshotId, source).build();
  }