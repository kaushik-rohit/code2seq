public AccumulatorSnapshot getSnapshot() {
		try {
			return new AccumulatorSnapshot(jobID, taskID, userAccumulators);
		} catch (Throwable e) {
			LOG.warn("Failed to serialize accumulators for task.", e);
			return null;
		}
	}