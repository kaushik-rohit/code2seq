public static String readString(URL url, String charset) throws IORuntimeException {
		if (url == null) {
			throw new NullPointerException("Empty url provided!");
		}

		InputStream in = null;
		try {
			in = url.openStream();
			return IoUtil.read(in, charset);
		} catch (IOException e) {
			throw new IORuntimeException(e);
		} finally {
			IoUtil.close(in);
		}
	}