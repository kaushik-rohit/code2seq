void updateSummary(CompletedCheckpointStats completed) {
		stateSize.add(completed.getStateSize());
		duration.add(completed.getEndToEndDuration());
		alignmentBuffered.add(completed.getAlignmentBuffered());
	}