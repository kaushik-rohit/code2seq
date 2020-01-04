public void start(JobLeaderIdActions initialJobLeaderIdActions) throws Exception {
		if (isStarted()) {
			clear();
		}

		this.jobLeaderIdActions = Preconditions.checkNotNull(initialJobLeaderIdActions);
	}