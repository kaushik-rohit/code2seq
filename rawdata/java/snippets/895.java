public static <T> File appendUtf8Lines(Collection<T> list, File file) throws IORuntimeException {
		return appendLines(list, file, CharsetUtil.CHARSET_UTF_8);
	}