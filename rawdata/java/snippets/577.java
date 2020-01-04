public void startCheckpointScheduler() {
		synchronized (lock) {
			if (shutdown) {
				throw new IllegalArgumentException("Checkpoint coordinator is shut down");
			}

			// make sure all prior timers are cancelled
			stopCheckpointScheduler();

			periodicScheduling = true;
			long initialDelay = ThreadLocalRandom.current().nextLong(
				minPauseBetweenCheckpointsNanos / 1_000_000L, baseInterval + 1L);
			currentPeriodicTrigger = timer.scheduleAtFixedRate(
					new ScheduledTrigger(), initialDelay, baseInterval, TimeUnit.MILLISECONDS);
		}
	}