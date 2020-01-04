public static Map<String, ValueType> rowSignatureFor(final GroupByQuery query)
  {
    final ImmutableMap.Builder<String, ValueType> types = ImmutableMap.builder();

    for (DimensionSpec dimensionSpec : query.getDimensions()) {
      types.put(dimensionSpec.getOutputName(), dimensionSpec.getOutputType());
    }

    for (AggregatorFactory aggregatorFactory : query.getAggregatorSpecs()) {
      final String typeName = aggregatorFactory.getTypeName();
      final ValueType valueType;
      if (typeName != null) {
        valueType = GuavaUtils.getEnumIfPresent(ValueType.class, StringUtils.toUpperCase(typeName));
      } else {
        valueType = null;
      }
      if (valueType != null) {
        types.put(aggregatorFactory.getName(), valueType);
      }
    }

    // Don't include post-aggregators since we don't know what types they are.
    return types.build();
  }