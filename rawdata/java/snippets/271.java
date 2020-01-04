private Map<String, Object> generateEmptyEventsFromAggregators(Map<String, AggregatorFactory> aggMap,
                                                                 Map<String, PostAggregator> postAggMap)
  {
    Map<String, Object> emptyEvents = new LinkedHashMap<>();
    aggMap.values().forEach(agg -> {
      Aggregator aggFactorized = agg.factorize(getEmptyColumnSelectorFactory());
      emptyEvents.put(agg.getName(), aggFactorized.get());
    });
    postAggMap.values().forEach(postAgg -> emptyEvents.put(postAgg.getName(), postAgg.compute(emptyEvents)));
    return emptyEvents;
  }