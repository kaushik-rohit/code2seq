public static Response getRedirectResponse(final String url, final Map<String, String> parameters) {
        val builder = new StringBuilder(parameters.size() * RESPONSE_INITIAL_CAPACITY);
        val sanitizedUrl = sanitizeUrl(url);
        LOGGER.debug("Sanitized URL for redirect response is [{}]", sanitizedUrl);
        val fragmentSplit = Splitter.on("#").splitToList(sanitizedUrl);
        builder.append(fragmentSplit.get(0));
        val params = parameters.entrySet()
            .stream()
            .filter(entry -> entry.getValue() != null)
            .map(entry -> {
                try {
                    return String.join("=", entry.getKey(), EncodingUtils.urlEncode(entry.getValue()));
                } catch (final Exception e) {
                    return String.join("=", entry.getKey(), entry.getValue());
                }
            })
            .collect(Collectors.joining("&"));
        if (!(params == null || params.isEmpty())) {
            builder.append(url.contains("?") ? "&" : "?");
            builder.append(params);
        }
        if (fragmentSplit.size() > 1) {
            builder.append('#');
            builder.append(fragmentSplit.get(1));
        }
        val urlRedirect = builder.toString();
        LOGGER.debug("Final redirect response is [{}]", urlRedirect);
        return new DefaultResponse(ResponseType.REDIRECT, urlRedirect, parameters);
    }