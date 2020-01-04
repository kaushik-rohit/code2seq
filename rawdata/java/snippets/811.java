private String obtainMatchingRedirect(Set<String> redirectUris, String requestedRedirect) {
		Assert.notEmpty(redirectUris, "Redirect URIs cannot be empty");

		if (redirectUris.size() == 1 && requestedRedirect == null) {
			return redirectUris.iterator().next();
		}

		for (String redirectUri : redirectUris) {
			if (requestedRedirect != null && redirectMatches(requestedRedirect, redirectUri)) {
				// Initialize with the registered redirect-uri
				UriComponentsBuilder redirectUriBuilder = UriComponentsBuilder.fromUriString(redirectUri);

				UriComponents requestedRedirectUri = UriComponentsBuilder.fromUriString(requestedRedirect).build();

				if (this.matchSubdomains) {
					redirectUriBuilder.host(requestedRedirectUri.getHost());
				}
				if (!this.matchPorts) {
					redirectUriBuilder.port(requestedRedirectUri.getPort());
				}
				redirectUriBuilder.replaceQuery(requestedRedirectUri.getQuery());		// retain additional params (if any)
				redirectUriBuilder.fragment(null);
				return redirectUriBuilder.build().toUriString();
			}
		}

		throw new RedirectMismatchException("Invalid redirect: " + requestedRedirect
				+ " does not match one of the registered values.");
	}