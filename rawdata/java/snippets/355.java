private CompletableFuture<KvStateLocation> getKvStateLookupInfo(
			final JobID jobId,
			final String queryableStateName,
			final boolean forceUpdate) {

		final Tuple2<JobID, String> cacheKey = new Tuple2<>(jobId, queryableStateName);
		final CompletableFuture<KvStateLocation> cachedFuture = lookupCache.get(cacheKey);

		if (!forceUpdate && cachedFuture != null && !cachedFuture.isCompletedExceptionally()) {
			LOG.debug("Retrieving location for state={} of job={} from the cache.", queryableStateName, jobId);
			return cachedFuture;
		}

		final KvStateLocationOracle kvStateLocationOracle = proxy.getKvStateLocationOracle(jobId);

		if (kvStateLocationOracle != null) {
			LOG.debug("Retrieving location for state={} of job={} from the key-value state location oracle.", queryableStateName, jobId);
			final CompletableFuture<KvStateLocation> location = new CompletableFuture<>();
			lookupCache.put(cacheKey, location);

			kvStateLocationOracle
				.requestKvStateLocation(jobId, queryableStateName)
				.whenComplete(
					(KvStateLocation kvStateLocation, Throwable throwable) -> {
						if (throwable != null) {
							if (ExceptionUtils.stripCompletionException(throwable) instanceof FlinkJobNotFoundException) {
								// if the jobId was wrong, remove the entry from the cache.
								lookupCache.remove(cacheKey);
							}
							location.completeExceptionally(throwable);
						} else {
							location.complete(kvStateLocation);
						}
					});

			return location;
		} else {
			return FutureUtils.completedExceptionally(
				new UnknownLocationException(
						"Could not retrieve location of state=" + queryableStateName + " of job=" + jobId +
								". Potential reasons are: i) the state is not ready, or ii) the job does not exist."));
		}
	}