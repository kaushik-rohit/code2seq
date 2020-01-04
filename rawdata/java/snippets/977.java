void start() throws IOException, InterruptedException {
		synchronized (startupShutdownLock) {
			LOG.info("Starting history server.");

			Files.createDirectories(webDir.toPath());
			LOG.info("Using directory {} as local cache.", webDir);

			Router router = new Router();
			router.addGet("/:*", new HistoryServerStaticFileServerHandler(webDir));

			if (!webDir.exists() && !webDir.mkdirs()) {
				throw new IOException("Failed to create local directory " + webDir.getAbsoluteFile() + ".");
			}

			createDashboardConfigFile();

			archiveFetcher.start();

			netty = new WebFrontendBootstrap(router, LOG, webDir, serverSSLFactory, webAddress, webPort, config);
		}
	}