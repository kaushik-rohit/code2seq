public void notifyCheckpointComplete(long checkpointId, long timestamp) {
		final LogicalSlot slot = assignedResource;

		if (slot != null) {
			final TaskManagerGateway taskManagerGateway = slot.getTaskManagerGateway();

			taskManagerGateway.notifyCheckpointComplete(attemptId, getVertex().getJobId(), checkpointId, timestamp);
		} else {
			LOG.debug("The execution has no slot assigned. This indicates that the execution is " +
				"no longer running.");
		}
	}