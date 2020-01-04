public String[] getDbStoragePaths() {
		if (localRocksDbDirectories == null) {
			return null;
		} else {
			String[] paths = new String[localRocksDbDirectories.length];
			for (int i = 0; i < paths.length; i++) {
				paths[i] = localRocksDbDirectories[i].toString();
			}
			return paths;
		}
	}