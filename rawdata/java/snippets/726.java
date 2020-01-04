public static void main(String[] args) throws IOException, ClassNotFoundException {
		String outputDirectory = args[0];
		String rootDir = args[1];

		for (OptionsClassLocation location : LOCATIONS) {
			createTable(rootDir, location.getModule(), location.getPackage(), outputDirectory, DEFAULT_PATH_PREFIX);
		}

		generateCommonSection(rootDir, outputDirectory, LOCATIONS, DEFAULT_PATH_PREFIX);
	}