@SuppressWarnings("unchecked")
	public T initKeys() {
		KeyPair keyPair = SecureUtil.generateKeyPair(this.algorithm);
		this.publicKey = keyPair.getPublic();
		this.privateKey = keyPair.getPrivate();
		return (T) this;
	}