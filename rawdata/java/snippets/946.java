public boolean add(Task task) {
		// Check that this slot has been assigned to the job sending this task
		Preconditions.checkArgument(task.getJobID().equals(jobId), "The task's job id does not match the " +
			"job id for which the slot has been allocated.");
		Preconditions.checkArgument(task.getAllocationId().equals(allocationId), "The task's allocation " +
			"id does not match the allocation id for which the slot has been allocated.");
		Preconditions.checkState(TaskSlotState.ACTIVE == state, "The task slot is not in state active.");

		Task oldTask = tasks.put(task.getExecutionId(), task);

		if (oldTask != null) {
			tasks.put(task.getExecutionId(), oldTask);
			return false;
		} else {
			return true;
		}
	}