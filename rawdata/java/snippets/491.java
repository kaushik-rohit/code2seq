public static HttpResponse execute(final String url, final String method,
                                       final String basicAuthUsername, final String basicAuthPassword,
                                       final Map<String, Object> headers) {
        return execute(url, method, basicAuthUsername, basicAuthPassword, new HashMap<>(), headers);
    }