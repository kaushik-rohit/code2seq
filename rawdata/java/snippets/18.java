protected void handle(HttpConnection httpConnection) throws IOException {
		try {
			getServerThread().handleIncomingHttp(httpConnection);
			httpConnection.waitForResponse();
		}
		catch (ConnectException ex) {
			httpConnection.respond(HttpStatus.GONE);
		}
	}