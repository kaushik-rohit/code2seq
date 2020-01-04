@Deprecated
	public static <T> T load(ReaderHandler<T> readerHandler, String path, String charset) throws IORuntimeException {
		return FileReader.create(file(path), CharsetUtil.charset(charset)).read(readerHandler);
	}