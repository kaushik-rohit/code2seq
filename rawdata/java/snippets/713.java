public static long downloadFile(String url, String dest) {
		return downloadFile(url, FileUtil.file(dest));
	}