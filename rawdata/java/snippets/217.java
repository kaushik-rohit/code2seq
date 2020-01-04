public static byte[] utf8Encode(CharSequence string) {
		try {
			ByteBuffer bytes = UTF8.newEncoder().encode(CharBuffer.wrap(string));
			byte[] bytesCopy = new byte[bytes.limit()];
			System.arraycopy(bytes.array(), 0, bytesCopy, 0, bytes.limit());
			return bytesCopy;
		}
		catch (CharacterCodingException e) {
			throw new RuntimeException(e);
		}
	}