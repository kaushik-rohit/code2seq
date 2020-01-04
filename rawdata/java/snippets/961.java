private void initFileSystem() throws IOException {
		if (fs == null) {
			Path path = new Path(basePath);
			fs = createHadoopFileSystem(path, fsConfig);
		}
	}