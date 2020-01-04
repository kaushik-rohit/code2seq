private Observable<HttpClientResponse<O>> submitToServerInURI(
            HttpClientRequest<I> request, IClientConfig requestConfig, ClientConfig config,
            RetryHandler errorHandler, ExecutionContext<HttpClientRequest<I>> context)  {
        // First, determine server from the URI
        URI uri;
        try {
            uri = new URI(request.getUri());
        } catch (URISyntaxException e) {
            return Observable.error(e);
        }
        String host = uri.getHost();
        if (host == null) {
            return null;
        }
        int port = uri.getPort();
        if (port < 0) {
            if (Optional.ofNullable(clientConfig.get(IClientConfigKey.Keys.IsSecure)).orElse(false)) {
                port = 443;
            } else {
                port = 80;
            }
        }
        
        return LoadBalancerCommand.<HttpClientResponse<O>>builder()
                .withRetryHandler(errorHandler)
                .withLoadBalancerContext(lbContext)
                .withListeners(listeners)
                .withExecutionContext(context)
                .withServer(new Server(host, port))
                .build()
                .submit(this.requestToOperation(request, getRxClientConfig(requestConfig, config)));
    }