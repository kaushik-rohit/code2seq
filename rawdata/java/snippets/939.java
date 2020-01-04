private CompletableFuture<LogicalSlot> allocateSingleSlot(
		SlotRequestId slotRequestId,
		SlotProfile slotProfile,
		boolean allowQueuedScheduling,
		Time allocationTimeout) {

		Optional<SlotAndLocality> slotAndLocality = tryAllocateFromAvailable(slotRequestId, slotProfile);

		if (slotAndLocality.isPresent()) {
			// already successful from available
			try {
				return CompletableFuture.completedFuture(
					completeAllocationByAssigningPayload(slotRequestId, slotAndLocality.get()));
			} catch (FlinkException e) {
				return FutureUtils.completedExceptionally(e);
			}
		} else if (allowQueuedScheduling) {
			// we allocate by requesting a new slot
			return slotPool
				.requestNewAllocatedSlot(slotRequestId, slotProfile.getResourceProfile(), allocationTimeout)
				.thenApply((PhysicalSlot allocatedSlot) -> {
					try {
						return completeAllocationByAssigningPayload(slotRequestId, new SlotAndLocality(allocatedSlot, Locality.UNKNOWN));
					} catch (FlinkException e) {
						throw new CompletionException(e);
					}
				});
		} else {
			// failed to allocate
			return FutureUtils.completedExceptionally(
				new NoResourceAvailableException("Could not allocate a simple slot for " + slotRequestId + '.'));
		}
	}