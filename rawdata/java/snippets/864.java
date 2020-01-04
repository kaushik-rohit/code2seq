void reportFailedCheckpoint(long failureTimestamp, @Nullable Throwable cause) {
		FailedCheckpointStats failed = new FailedCheckpointStats(
			checkpointId,
			triggerTimestamp,
			props,
			numberOfSubtasks,
			new HashMap<>(taskStats),
			currentNumAcknowledgedSubtasks,
			currentStateSize,
			currentAlignmentBuffered,
			failureTimestamp,
			latestAcknowledgedSubtask,
			cause);

		trackerCallback.reportFailedCheckpoint(failed);
	}