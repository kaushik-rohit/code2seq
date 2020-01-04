@VisibleForTesting
	void checkTaskManagerTimeouts() {
		if (!taskManagerRegistrations.isEmpty()) {
			long currentTime = System.currentTimeMillis();

			ArrayList<TaskManagerRegistration> timedOutTaskManagers = new ArrayList<>(taskManagerRegistrations.size());

			// first retrieve the timed out TaskManagers
			for (TaskManagerRegistration taskManagerRegistration : taskManagerRegistrations.values()) {
				if (currentTime - taskManagerRegistration.getIdleSince() >= taskManagerTimeout.toMilliseconds()) {
					// we collect the instance ids first in order to avoid concurrent modifications by the
					// ResourceActions.releaseResource call
					timedOutTaskManagers.add(taskManagerRegistration);
				}
			}

			// second we trigger the release resource callback which can decide upon the resource release
			for (TaskManagerRegistration taskManagerRegistration : timedOutTaskManagers) {
				InstanceID timedOutTaskManagerId = taskManagerRegistration.getInstanceId();
				if (waitResultConsumedBeforeRelease) {
					// checking whether TaskManagers can be safely removed
					taskManagerRegistration.getTaskManagerConnection().getTaskExecutorGateway().canBeReleased()
						.thenAcceptAsync(canBeReleased -> {
							if (canBeReleased) {
								releaseTaskExecutor(timedOutTaskManagerId);
							}},
							mainThreadExecutor);
				} else {
					releaseTaskExecutor(timedOutTaskManagerId);
				}
			}
		}
	}