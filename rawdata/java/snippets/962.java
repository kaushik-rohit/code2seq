public static Tag outcome(ServerWebExchange exchange) {
		HttpStatus status = exchange.getResponse().getStatusCode();
		if (status != null) {
			if (status.is1xxInformational()) {
				return OUTCOME_INFORMATIONAL;
			}
			if (status.is2xxSuccessful()) {
				return OUTCOME_SUCCESS;
			}
			if (status.is3xxRedirection()) {
				return OUTCOME_REDIRECTION;
			}
			if (status.is4xxClientError()) {
				return OUTCOME_CLIENT_ERROR;
			}
			return OUTCOME_SERVER_ERROR;
		}
		return OUTCOME_UNKNOWN;
	}