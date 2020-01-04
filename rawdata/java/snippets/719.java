public AioSession write(ByteBuffer data, CompletionHandler<Integer, AioSession> handler) {
		this.channel.write(data, Math.max(this.writeTimeout, 0L), TimeUnit.MILLISECONDS, this, handler);
		return this;
	}