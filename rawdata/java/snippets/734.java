public Scheduler schedule(String id, String pattern, Runnable task) {
		return schedule(id, new CronPattern(pattern), new RunnableTask(task));
	}