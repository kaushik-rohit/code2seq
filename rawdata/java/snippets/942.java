public Operation deprecate(
      DeprecationStatus<ImageId> deprecationStatus, OperationOption... options) {
    return compute.deprecate(getImageId(), deprecationStatus, options);
  }