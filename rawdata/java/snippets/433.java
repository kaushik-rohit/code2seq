@Override
	public void initializeState(FunctionInitializationContext context) throws Exception {
		final int subtaskIndex = getRuntimeContext().getIndexOfThisSubtask();
		this.buckets = bucketsBuilder.createBuckets(subtaskIndex);

		final OperatorStateStore stateStore = context.getOperatorStateStore();
		bucketStates = stateStore.getListState(BUCKET_STATE_DESC);
		maxPartCountersState = stateStore.getUnionListState(MAX_PART_COUNTER_STATE_DESC);

		if (context.isRestored()) {
			buckets.initializeState(bucketStates, maxPartCountersState);
		}
	}