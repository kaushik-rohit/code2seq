public static void open(File file) {
		final Desktop dsktop = getDsktop();
		try {
			dsktop.open(file);
		} catch (IOException e) {
			throw new IORuntimeException(e);
		}
	}