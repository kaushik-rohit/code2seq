public static ByteBuffer copy(ByteBuffer src, int srcStart, ByteBuffer dest, int destStart, int length) {
		System.arraycopy(src.array(), srcStart, dest.array(), destStart, length);
		return dest;
	}