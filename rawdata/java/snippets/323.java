public boolean isAbsolute() {
		final int start = hasWindowsDrive(uri.getPath(), true) ? 3 : 0;
		return uri.getPath().startsWith(SEPARATOR, start);
	}