public static File appendString(String content, File file, String charset) throws IORuntimeException {
		return FileWriter.create(file, CharsetUtil.charset(charset)).append(content);
	}