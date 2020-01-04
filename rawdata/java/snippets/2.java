@Override
	public void runFetchLoop() throws Exception {
		// the map from broker to the thread that is connected to that broker
		final Map<Node, SimpleConsumerThread<T>> brokerToThread = new HashMap<>();

		// this holds possible the exceptions from the concurrent broker connection threads
		final ExceptionProxy errorHandler = new ExceptionProxy(Thread.currentThread());

		// the offset handler handles the communication with ZooKeeper, to commit externally visible offsets
		final ZookeeperOffsetHandler zookeeperOffsetHandler = new ZookeeperOffsetHandler(kafkaConfig);
		this.zookeeperOffsetHandler = zookeeperOffsetHandler;

		PeriodicOffsetCommitter periodicCommitter = null;
		try {

			// offsets in the state may still be placeholder sentinel values if we are starting fresh, or the
			// checkpoint / savepoint state we were restored with had not completely been replaced with actual offset
			// values yet; replace those with actual offsets, according to what the sentinel value represent.
			for (KafkaTopicPartitionState<TopicAndPartition> partition : subscribedPartitionStates()) {
				if (partition.getOffset() == KafkaTopicPartitionStateSentinel.EARLIEST_OFFSET) {
					// this will be replaced by an actual offset in SimpleConsumerThread
					partition.setOffset(OffsetRequest.EarliestTime());
				} else if (partition.getOffset() == KafkaTopicPartitionStateSentinel.LATEST_OFFSET) {
					// this will be replaced by an actual offset in SimpleConsumerThread
					partition.setOffset(OffsetRequest.LatestTime());
				} else if (partition.getOffset() == KafkaTopicPartitionStateSentinel.GROUP_OFFSET) {
					Long committedOffset = zookeeperOffsetHandler.getCommittedOffset(partition.getKafkaTopicPartition());
					if (committedOffset != null) {
						// the committed offset in ZK represents the next record to process,
						// so we subtract it by 1 to correctly represent internal state
						partition.setOffset(committedOffset - 1);
					} else {
						// if we can't find an offset for a partition in ZK when using GROUP_OFFSETS,
						// we default to "auto.offset.reset" like the Kafka high-level consumer
						LOG.warn("No group offset can be found for partition {} in Zookeeper;" +
							" resetting starting offset to 'auto.offset.reset'", partition);

						partition.setOffset(invalidOffsetBehavior);
					}
				} else {
					// the partition already has a specific start offset and is ready to be consumed
				}
			}

			// start the periodic offset committer thread, if necessary
			if (autoCommitInterval > 0) {
				LOG.info("Starting periodic offset committer, with commit interval of {}ms", autoCommitInterval);

				periodicCommitter = new PeriodicOffsetCommitter(
						zookeeperOffsetHandler,
						subscribedPartitionStates(),
						errorHandler,
						autoCommitInterval);
				periodicCommitter.setName("Periodic Kafka partition offset committer");
				periodicCommitter.setDaemon(true);
				periodicCommitter.start();
			}

			// Main loop polling elements from the unassignedPartitions queue to the threads
			while (running) {
				// re-throw any exception from the concurrent fetcher threads
				errorHandler.checkAndThrowException();

				// wait for max 5 seconds trying to get partitions to assign
				// if threads shut down, this poll returns earlier, because the threads inject the
				// special marker into the queue
				List<KafkaTopicPartitionState<TopicAndPartition>> partitionsToAssign =
						unassignedPartitionsQueue.getBatchBlocking(5000);
				// note: if there are more markers, remove them all
				partitionsToAssign.removeIf(MARKER::equals);

				if (!partitionsToAssign.isEmpty()) {
					LOG.info("Assigning {} partitions to broker threads", partitionsToAssign.size());
					Map<Node, List<KafkaTopicPartitionState<TopicAndPartition>>> partitionsWithLeaders =
							findLeaderForPartitions(partitionsToAssign, kafkaConfig);

					// assign the partitions to the leaders (maybe start the threads)
					for (Map.Entry<Node, List<KafkaTopicPartitionState<TopicAndPartition>>> partitionsWithLeader :
							partitionsWithLeaders.entrySet()) {
						final Node leader = partitionsWithLeader.getKey();
						final List<KafkaTopicPartitionState<TopicAndPartition>> partitions = partitionsWithLeader.getValue();
						SimpleConsumerThread<T> brokerThread = brokerToThread.get(leader);

						if (!running) {
							break;
						}

						if (brokerThread == null || !brokerThread.getNewPartitionsQueue().isOpen()) {
							// start new thread
							brokerThread = createAndStartSimpleConsumerThread(partitions, leader, errorHandler);
							brokerToThread.put(leader, brokerThread);
						}
						else {
							// put elements into queue of thread
							ClosableBlockingQueue<KafkaTopicPartitionState<TopicAndPartition>> newPartitionsQueue =
									brokerThread.getNewPartitionsQueue();

							for (KafkaTopicPartitionState<TopicAndPartition> fp : partitions) {
								if (!newPartitionsQueue.addIfOpen(fp)) {
									// we were unable to add the partition to the broker's queue
									// the broker has closed in the meantime (the thread will shut down)
									// create a new thread for connecting to this broker
									List<KafkaTopicPartitionState<TopicAndPartition>> seedPartitions = new ArrayList<>();
									seedPartitions.add(fp);
									brokerThread = createAndStartSimpleConsumerThread(seedPartitions, leader, errorHandler);
									brokerToThread.put(leader, brokerThread);
									newPartitionsQueue = brokerThread.getNewPartitionsQueue(); // update queue for the subsequent partitions
								}
							}
						}
					}
				}
				else {
					// there were no partitions to assign. Check if any broker threads shut down.
					// we get into this section of the code, if either the poll timed out, or the
					// blocking poll was woken up by the marker element
					Iterator<SimpleConsumerThread<T>> bttIterator = brokerToThread.values().iterator();
					while (bttIterator.hasNext()) {
						SimpleConsumerThread<T> thread = bttIterator.next();
						if (!thread.getNewPartitionsQueue().isOpen()) {
							LOG.info("Removing stopped consumer thread {}", thread.getName());
							bttIterator.remove();
						}
					}
				}

				if (brokerToThread.size() == 0 && unassignedPartitionsQueue.isEmpty()) {
					if (unassignedPartitionsQueue.close()) {
						LOG.info("All consumer threads are finished, there are no more unassigned partitions. Stopping fetcher");
						break;
					}
					// we end up here if somebody added something to the queue in the meantime --> continue to poll queue again
				}
			}
		}
		catch (InterruptedException e) {
			// this may be thrown because an exception on one of the concurrent fetcher threads
			// woke this thread up. make sure we throw the root exception instead in that case
			errorHandler.checkAndThrowException();

			// no other root exception, throw the interrupted exception
			throw e;
		}
		finally {
			this.running = false;
			this.zookeeperOffsetHandler = null;

			// if we run a periodic committer thread, shut that down
			if (periodicCommitter != null) {
				periodicCommitter.shutdown();
			}

			// clear the interruption flag
			// this allows the joining on consumer threads (on best effort) to happen in
			// case the initial interrupt already
			Thread.interrupted();

			// make sure that in any case (completion, abort, error), all spawned threads are stopped
			try {
				int runningThreads;
				do {
					// check whether threads are alive and cancel them
					runningThreads = 0;
					Iterator<SimpleConsumerThread<T>> threads = brokerToThread.values().iterator();
					while (threads.hasNext()) {
						SimpleConsumerThread<?> t = threads.next();
						if (t.isAlive()) {
							t.cancel();
							runningThreads++;
						} else {
							threads.remove();
						}
					}

					// wait for the threads to finish, before issuing a cancel call again
					if (runningThreads > 0) {
						for (SimpleConsumerThread<?> t : brokerToThread.values()) {
							t.join(500 / runningThreads + 1);
						}
					}
				}
				while (runningThreads > 0);
			}
			catch (InterruptedException ignored) {
				// waiting for the thread shutdown apparently got interrupted
				// restore interrupted state and continue
				Thread.currentThread().interrupt();
			}
			catch (Throwable t) {
				// we catch all here to preserve the original exception
				LOG.error("Exception while shutting down consumer threads", t);
			}

			try {
				zookeeperOffsetHandler.close();
			}
			catch (Throwable t) {
				// we catch all here to preserve the original exception
				LOG.error("Exception while shutting down ZookeeperOffsetHandler", t);
			}
		}
	}