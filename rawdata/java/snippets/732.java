@VisibleForTesting
  static List<IndexIngestionSpec> createIngestionSchema(
      final TaskToolbox toolbox,
      final SegmentProvider segmentProvider,
      final PartitionConfigurationManager partitionConfigurationManager,
      @Nullable final DimensionsSpec dimensionsSpec,
      @Nullable final AggregatorFactory[] metricsSpec,
      @Nullable final Boolean keepSegmentGranularity,
      @Nullable final Granularity segmentGranularity,
      final ObjectMapper jsonMapper,
      final CoordinatorClient coordinatorClient,
      final SegmentLoaderFactory segmentLoaderFactory,
      final RetryPolicyFactory retryPolicyFactory
  ) throws IOException, SegmentLoadingException
  {
    Pair<Map<DataSegment, File>, List<TimelineObjectHolder<String, DataSegment>>> pair = prepareSegments(
        toolbox,
        segmentProvider
    );
    final Map<DataSegment, File> segmentFileMap = pair.lhs;
    final List<TimelineObjectHolder<String, DataSegment>> timelineSegments = pair.rhs;

    if (timelineSegments.size() == 0) {
      return Collections.emptyList();
    }

    // find metadata for interval
    final List<Pair<QueryableIndex, DataSegment>> queryableIndexAndSegments = loadSegments(
        timelineSegments,
        segmentFileMap,
        toolbox.getIndexIO()
    );

    final IndexTuningConfig compactionTuningConfig = partitionConfigurationManager.computeTuningConfig(
        queryableIndexAndSegments
    );

    if (segmentGranularity == null) {
      if (keepSegmentGranularity != null && !keepSegmentGranularity) {
        // all granularity
        final DataSchema dataSchema = createDataSchema(
            segmentProvider.dataSource,
            segmentProvider.interval,
            queryableIndexAndSegments,
            dimensionsSpec,
            metricsSpec,
            Granularities.ALL,
            jsonMapper
        );

        return Collections.singletonList(
            new IndexIngestionSpec(
                dataSchema,
                createIoConfig(
                    toolbox,
                    dataSchema,
                    segmentProvider.interval,
                    coordinatorClient,
                    segmentLoaderFactory,
                    retryPolicyFactory
                ),
                compactionTuningConfig
            )
        );
      } else {
        // original granularity
        final Map<Interval, List<Pair<QueryableIndex, DataSegment>>> intervalToSegments = new TreeMap<>(
            Comparators.intervalsByStartThenEnd()
        );
        //noinspection ConstantConditions
        queryableIndexAndSegments.forEach(
            p -> intervalToSegments.computeIfAbsent(p.rhs.getInterval(), k -> new ArrayList<>())
                                   .add(p)
        );

        final List<IndexIngestionSpec> specs = new ArrayList<>(intervalToSegments.size());
        for (Entry<Interval, List<Pair<QueryableIndex, DataSegment>>> entry : intervalToSegments.entrySet()) {
          final Interval interval = entry.getKey();
          final List<Pair<QueryableIndex, DataSegment>> segmentsToCompact = entry.getValue();
          final DataSchema dataSchema = createDataSchema(
              segmentProvider.dataSource,
              interval,
              segmentsToCompact,
              dimensionsSpec,
              metricsSpec,
              GranularityType.fromPeriod(interval.toPeriod()).getDefaultGranularity(),
              jsonMapper
          );

          specs.add(
              new IndexIngestionSpec(
                  dataSchema,
                  createIoConfig(
                      toolbox,
                      dataSchema,
                      interval,
                      coordinatorClient,
                      segmentLoaderFactory,
                      retryPolicyFactory
                  ),
                  compactionTuningConfig
              )
          );
        }

        return specs;
      }
    } else {
      if (keepSegmentGranularity != null && keepSegmentGranularity) {
        // error
        throw new ISE("segmentGranularity[%s] and keepSegmentGranularity can't be used together", segmentGranularity);
      } else {
        // given segment granularity
        final DataSchema dataSchema = createDataSchema(
            segmentProvider.dataSource,
            segmentProvider.interval,
            queryableIndexAndSegments,
            dimensionsSpec,
            metricsSpec,
            segmentGranularity,
            jsonMapper
        );

        return Collections.singletonList(
            new IndexIngestionSpec(
                dataSchema,
                createIoConfig(
                    toolbox,
                    dataSchema,
                    segmentProvider.interval,
                    coordinatorClient,
                    segmentLoaderFactory,
                    retryPolicyFactory
                ),
                compactionTuningConfig
            )
        );
      }
    }
  }