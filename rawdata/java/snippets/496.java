public static RegionOperationId of(RegionId regionId, String operation) {
    return new RegionOperationId(regionId.getProject(), regionId.getRegion(), operation);
  }