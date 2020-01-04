public HttpRequest setSSLProtocol(String protocol) {
		if (null == this.ssf) {
			try {
				this.ssf = SSLSocketFactoryBuilder.create().setProtocol(protocol).build();
			} catch (Exception e) {
				throw new HttpException(e);
			}
		}
		return this;
	}