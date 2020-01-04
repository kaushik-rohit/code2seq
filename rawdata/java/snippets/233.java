@SuppressWarnings("WeakerAccess")
  public UpdateInstanceRequest setAllLabels(@Nonnull Map<String, String> labels) {
    Preconditions.checkNotNull(labels, "labels can't be null");
    builder.getInstanceBuilder().clearLabels();
    builder.getInstanceBuilder().putAllLabels(labels);
    updateFieldMask(Instance.LABELS_FIELD_NUMBER);

    return this;
  }