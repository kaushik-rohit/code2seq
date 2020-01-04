public boolean reachEnd() throws IOException {
		// check if we have a read row that was not returned yet
		if (readRecord != null && !readRecordReturned) {
			return false;
		}
		// check if there are more rows to be read
		if (numReadRecords >= numTotalRecords) {
			return true;
		}
		// try to read next row
		return !readNextRecord();
	}