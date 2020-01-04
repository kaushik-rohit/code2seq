public static void loadPropsBySuffix(final File jobPath, final Props props,
      final String... suffixes) {
    try {
      if (jobPath.isDirectory()) {
        final File[] files = jobPath.listFiles();
        if (files != null) {
          for (final File file : files) {
            loadPropsBySuffix(file, props, suffixes);
          }
        }
      } else if (endsWith(jobPath, suffixes)) {
        props.putAll(new Props(null, jobPath.getAbsolutePath()));
      }
    } catch (final IOException e) {
      throw new RuntimeException("Error loading schedule properties.", e);
    }
  }