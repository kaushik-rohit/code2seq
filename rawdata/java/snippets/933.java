public static KeyGenerator getKeyGenerator(String algorithm) {
		final Provider provider = GlobalBouncyCastleProvider.INSTANCE.getProvider();

		KeyGenerator generator;
		try {
			generator = (null == provider) //
					? KeyGenerator.getInstance(getMainAlgorithm(algorithm)) //
					: KeyGenerator.getInstance(getMainAlgorithm(algorithm), provider);
		} catch (NoSuchAlgorithmException e) {
			throw new CryptoException(e);
		}
		return generator;
	}