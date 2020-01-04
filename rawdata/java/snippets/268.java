public DataSink<T> writeAsCsv(String filePath, String rowDelimiter, String fieldDelimiter, WriteMode writeMode) {
		return internalWriteAsCsv(new Path(filePath), rowDelimiter, fieldDelimiter, writeMode);
	}