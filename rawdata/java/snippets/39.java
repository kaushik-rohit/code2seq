@Override
	public Optional<ResourceID> failAllocation(final AllocationID allocationID, final Exception cause) {

		componentMainThreadExecutor.assertRunningInMainThread();

		final PendingRequest pendingRequest = pendingRequests.removeKeyB(allocationID);
		if (pendingRequest != null) {
			// request was still pending
			failPendingRequest(pendingRequest, cause);
			return Optional.empty();
		}
		else {
			return tryFailingAllocatedSlot(allocationID, cause);
		}

		// TODO: add some unit tests when the previous two are ready, the allocation may failed at any phase
	}