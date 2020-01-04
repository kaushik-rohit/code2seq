public String getOneTimeNonce(String apiUrl) {
		String nonce = Long.toHexString(random.nextLong());
		this.nonces.put(nonce, new Nonce(nonce, apiUrl, true));
		return nonce;
	}