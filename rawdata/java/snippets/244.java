public static List<String> readUtf8Lines(File file) throws IORuntimeException {
		return readLines(file, CharsetUtil.CHARSET_UTF_8);
	}