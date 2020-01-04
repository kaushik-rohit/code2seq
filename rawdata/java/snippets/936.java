@Override
	public CompletableFuture<Void> closeAsync() {
		synchronized (lock) {
			if (running) {
				LOG.info("Shutting down Flink Mini Cluster");
				try {
					final long shutdownTimeoutMillis = miniClusterConfiguration.getConfiguration().getLong(ClusterOptions.CLUSTER_SERVICES_SHUTDOWN_TIMEOUT);
					final int numComponents = 2 + miniClusterConfiguration.getNumTaskManagers();
					final Collection<CompletableFuture<Void>> componentTerminationFutures = new ArrayList<>(numComponents);

					componentTerminationFutures.addAll(terminateTaskExecutors());

					componentTerminationFutures.add(shutDownResourceManagerComponents());

					final FutureUtils.ConjunctFuture<Void> componentsTerminationFuture = FutureUtils.completeAll(componentTerminationFutures);

					final CompletableFuture<Void> metricSystemTerminationFuture = FutureUtils.composeAfterwards(
						componentsTerminationFuture,
						this::closeMetricSystem);

					// shut down the RpcServices
					final CompletableFuture<Void> rpcServicesTerminationFuture = metricSystemTerminationFuture
						.thenCompose((Void ignored) -> terminateRpcServices());

					final CompletableFuture<Void> remainingServicesTerminationFuture = FutureUtils.runAfterwards(
						rpcServicesTerminationFuture,
						this::terminateMiniClusterServices);

					final CompletableFuture<Void> executorsTerminationFuture = FutureUtils.runAfterwards(
						remainingServicesTerminationFuture,
						() -> terminateExecutors(shutdownTimeoutMillis));

					executorsTerminationFuture.whenComplete(
							(Void ignored, Throwable throwable) -> {
								if (throwable != null) {
									terminationFuture.completeExceptionally(ExceptionUtils.stripCompletionException(throwable));
								} else {
									terminationFuture.complete(null);
								}
							});
				} finally {
					running = false;
				}
			}

			return terminationFuture;
		}
	}