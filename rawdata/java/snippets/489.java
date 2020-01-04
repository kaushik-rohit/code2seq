protected String getUserAuthorizationRedirectURL(ProtectedResourceDetails details, OAuthConsumerToken requestToken, String callbackURL) {
		try {
			String baseURL = details.getUserAuthorizationURL();
			StringBuilder builder = new StringBuilder(baseURL);
			char appendChar = baseURL.indexOf('?') < 0 ? '?' : '&';
			builder.append(appendChar).append("oauth_token=");
			builder.append(URLEncoder.encode(requestToken.getValue(), "UTF-8"));
			if (!details.isUse10a()) {
				builder.append('&').append("oauth_callback=");
				builder.append(URLEncoder.encode(callbackURL, "UTF-8"));
			}
			return builder.toString();
		}
		catch (UnsupportedEncodingException e) {
			throw new IllegalStateException(e);
		}
	}