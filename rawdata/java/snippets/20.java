public static void next(HttpServerExchange httpServerExchange, String execName, Boolean returnToOrigFlow)
			throws Exception {
		String currentChainId = httpServerExchange.getAttachment(CHAIN_ID);
		Integer currentNextIndex = httpServerExchange.getAttachment(CHAIN_SEQ);

		httpServerExchange.putAttachment(CHAIN_ID, execName);
		httpServerExchange.putAttachment(CHAIN_SEQ, 0);

		next(httpServerExchange);

		// return to current flow.
		if (returnToOrigFlow) {
			httpServerExchange.putAttachment(CHAIN_ID, currentChainId);
			httpServerExchange.putAttachment(CHAIN_SEQ, currentNextIndex);
			next(httpServerExchange);
		}
	}