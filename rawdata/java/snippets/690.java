public String readHeader() throws IOException {
		byte[] buffer = new byte[BUFFER_SIZE];
		StringBuilder content = new StringBuilder(BUFFER_SIZE);
		while (content.indexOf(HEADER_END) == -1) {
			int amountRead = checkedRead(buffer, 0, BUFFER_SIZE);
			content.append(new String(buffer, 0, amountRead));
		}
		return content.substring(0, content.indexOf(HEADER_END));
	}