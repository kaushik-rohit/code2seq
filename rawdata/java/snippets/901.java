public static byte[] decode(String key) {
		return Validator.isHex(key) ? HexUtil.decodeHex(key) : Base64.decode(key);
	}