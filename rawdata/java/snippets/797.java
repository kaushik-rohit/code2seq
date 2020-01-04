public static void readBySax(File file, int sheetIndex, RowHandler rowHandler) {
		BufferedInputStream in = null;
		try {
			in = FileUtil.getInputStream(file);
			readBySax(in, sheetIndex, rowHandler);
		} finally {
			IoUtil.close(in);
		}
	}