public IntermediateResultPartition getPartitionById(IntermediateResultPartitionID resultPartitionId) {
		// Looks ups the partition number via the helper map and returns the
		// partition. Currently, this happens infrequently enough that we could
		// consider removing the map and scanning the partitions on every lookup.
		// The lookup (currently) only happen when the producer of an intermediate
		// result cannot be found via its registered execution.
		Integer partitionNumber = partitionLookupHelper.get(checkNotNull(resultPartitionId, "IntermediateResultPartitionID"));
		if (partitionNumber != null) {
			return partitions[partitionNumber];
		} else {
			throw new IllegalArgumentException("Unknown intermediate result partition ID " + resultPartitionId);
		}
	}