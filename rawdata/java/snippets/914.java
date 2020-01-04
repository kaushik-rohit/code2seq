private static void validateForCurrentMode(HttpMessage request) throws ApiException {
		if (!isValidForCurrentMode(request.getRequestHeader().getURI())) {
			throw new ApiException(ApiException.Type.MODE_VIOLATION);
		}
	}