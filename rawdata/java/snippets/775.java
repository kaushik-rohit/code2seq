public void threadDump(String reasonMsg) {
		logger.info("Thread dump by ThreadDumpper" + (reasonMsg != null ? (" for " + reasonMsg) : ""));

		Map<Thread, StackTraceElement[]> threads = Thread.getAllStackTraces();
		// 两条日志间的时间间隔，是VM被thread dump堵塞的时间.
		logger.info("Finish the threads snapshot");

		StringBuilder sb = new StringBuilder(8192 * 20).append('\n');

		for (Entry<Thread, StackTraceElement[]> entry : threads.entrySet()) {
			dumpThreadInfo(entry.getKey(), entry.getValue(), sb);
		}
		logger.info(sb.toString());
	}