public boolean verify(byte[] data, byte[] sign) {
		lock.lock();
		try {
			signature.initVerify(this.publicKey);
			signature.update(data);
			return signature.verify(sign);
		} catch (Exception e) {
			throw new CryptoException(e);
		} finally {
			lock.unlock();
		}
	}