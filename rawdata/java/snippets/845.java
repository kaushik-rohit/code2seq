@EachBean(ServiceHttpClientConfiguration.class)
    @Requires(condition = ServiceHttpClientCondition.class)
    DefaultHttpClient serviceHttpClient(
            @Parameter ServiceHttpClientConfiguration configuration,
            @Parameter StaticServiceInstanceList instanceList) {
        List<URI> originalURLs = configuration.getUrls();
        Collection<URI> loadBalancedURIs = instanceList.getLoadBalancedURIs();
        boolean isHealthCheck = configuration.isHealthCheck();

        LoadBalancer loadBalancer = loadBalancerFactory.create(instanceList);

        Optional<String> path = configuration.getPath();
        DefaultHttpClient httpClient;
        if (path.isPresent()) {
            httpClient = beanContext.createBean(DefaultHttpClient.class, loadBalancer, configuration, path.get());
        } else {
            httpClient = beanContext.createBean(DefaultHttpClient.class, loadBalancer, configuration);
        }

        httpClient.setClientIdentifiers(configuration.getServiceId());

        if (isHealthCheck) {
            taskScheduler.scheduleWithFixedDelay(configuration.getHealthCheckInterval(), configuration.getHealthCheckInterval(), () -> Flowable.fromIterable(originalURLs).flatMap(originalURI -> {
                URI healthCheckURI = originalURI.resolve(configuration.getHealthCheckUri());
                return httpClient.exchange(HttpRequest.GET(healthCheckURI)).onErrorResumeNext(throwable -> {
                    if (throwable instanceof HttpClientResponseException) {
                        HttpClientResponseException responseException = (HttpClientResponseException) throwable;
                        HttpResponse response = responseException.getResponse();
                        //noinspection unchecked
                        return Flowable.just(response);
                    }
                    return Flowable.just(HttpResponse.serverError());
                }).map(response -> Collections.singletonMap(originalURI, response.getStatus()));
            }).subscribe(uriToStatusMap -> {
                Map.Entry<URI, HttpStatus> entry = uriToStatusMap.entrySet().iterator().next();

                URI uri = entry.getKey();
                HttpStatus status = entry.getValue();

                if (status.getCode() >= 300) {
                    loadBalancedURIs.remove(uri);
                } else if (!loadBalancedURIs.contains(uri)) {
                    loadBalancedURIs.add(uri);
                }
            }));
        }
        return httpClient;
    }