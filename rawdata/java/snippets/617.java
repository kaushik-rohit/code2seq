@Override
	public CompletableFuture<JobSubmissionResult> submitJob(@Nonnull JobGraph jobGraph) {
		// we have to enable queued scheduling because slot will be allocated lazily
		jobGraph.setAllowQueuedScheduling(true);

		CompletableFuture<java.nio.file.Path> jobGraphFileFuture = CompletableFuture.supplyAsync(() -> {
			try {
				final java.nio.file.Path jobGraphFile = Files.createTempFile("flink-jobgraph", ".bin");
				try (ObjectOutputStream objectOut = new ObjectOutputStream(Files.newOutputStream(jobGraphFile))) {
					objectOut.writeObject(jobGraph);
				}
				return jobGraphFile;
			} catch (IOException e) {
				throw new CompletionException(new FlinkException("Failed to serialize JobGraph.", e));
			}
		}, executorService);

		CompletableFuture<Tuple2<JobSubmitRequestBody, Collection<FileUpload>>> requestFuture = jobGraphFileFuture.thenApply(jobGraphFile -> {
			List<String> jarFileNames = new ArrayList<>(8);
			List<JobSubmitRequestBody.DistributedCacheFile> artifactFileNames = new ArrayList<>(8);
			Collection<FileUpload> filesToUpload = new ArrayList<>(8);

			filesToUpload.add(new FileUpload(jobGraphFile, RestConstants.CONTENT_TYPE_BINARY));

			for (Path jar : jobGraph.getUserJars()) {
				jarFileNames.add(jar.getName());
				filesToUpload.add(new FileUpload(Paths.get(jar.toUri()), RestConstants.CONTENT_TYPE_JAR));
			}

			for (Map.Entry<String, DistributedCache.DistributedCacheEntry> artifacts : jobGraph.getUserArtifacts().entrySet()) {
				artifactFileNames.add(new JobSubmitRequestBody.DistributedCacheFile(artifacts.getKey(), new Path(artifacts.getValue().filePath).getName()));
				filesToUpload.add(new FileUpload(Paths.get(artifacts.getValue().filePath), RestConstants.CONTENT_TYPE_BINARY));
			}

			final JobSubmitRequestBody requestBody = new JobSubmitRequestBody(
				jobGraphFile.getFileName().toString(),
				jarFileNames,
				artifactFileNames);

			return Tuple2.of(requestBody, Collections.unmodifiableCollection(filesToUpload));
		});

		final CompletableFuture<JobSubmitResponseBody> submissionFuture = requestFuture.thenCompose(
			requestAndFileUploads -> sendRetriableRequest(
				JobSubmitHeaders.getInstance(),
				EmptyMessageParameters.getInstance(),
				requestAndFileUploads.f0,
				requestAndFileUploads.f1,
				isConnectionProblemOrServiceUnavailable())
		);

		submissionFuture
			.thenCombine(jobGraphFileFuture, (ignored, jobGraphFile) -> jobGraphFile)
			.thenAccept(jobGraphFile -> {
			try {
				Files.delete(jobGraphFile);
			} catch (IOException e) {
				log.warn("Could not delete temporary file {}.", jobGraphFile, e);
			}
		});

		return submissionFuture
			.thenApply(
				(JobSubmitResponseBody jobSubmitResponseBody) -> new JobSubmissionResult(jobGraph.getJobID()))
			.exceptionally(
				(Throwable throwable) -> {
					throw new CompletionException(new JobSubmissionException(jobGraph.getJobID(), "Failed to submit JobGraph.", ExceptionUtils.stripCompletionException(throwable)));
				});
	}