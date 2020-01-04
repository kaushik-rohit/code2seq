public static Date lastModifiedTime(File file) {
		if (!exist(file)) {
			return null;
		}

		return new Date(file.lastModified());
	}