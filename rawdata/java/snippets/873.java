public <T extends Collection<String>> T readLines(T collection) throws IORuntimeException {
		BufferedReader reader = null;
		try {
			reader = FileUtil.getReader(file, charset);
			String line;
			while (true) {
				line = reader.readLine();
				if (line == null) {
					break;
				}
				collection.add(line);
			}
			return collection;
		} catch (IOException e) {
			throw new IORuntimeException(e);
		} finally {
			IoUtil.close(reader);
		}
	}