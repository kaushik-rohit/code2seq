public static Cipher createCipher(String algorithm) {
		final Provider provider = GlobalBouncyCastleProvider.INSTANCE.getProvider();

		Cipher cipher;
		try {
			cipher = (null == provider) ? Cipher.getInstance(algorithm) : Cipher.getInstance(algorithm, provider);
		} catch (Exception e) {
			throw new CryptoException(e);
		}

		return cipher;
	}