HystrixMetricsPublisherThreadPool getPublisherForThreadPool(HystrixThreadPoolKey threadPoolKey, HystrixThreadPoolMetrics metrics, HystrixThreadPoolProperties properties) {
        // attempt to retrieve from cache first
        HystrixMetricsPublisherThreadPool publisher = threadPoolPublishers.get(threadPoolKey.name());
        if (publisher != null) {
            return publisher;
        }
        // it doesn't exist so we need to create it
        publisher = HystrixPlugins.getInstance().getMetricsPublisher().getMetricsPublisherForThreadPool(threadPoolKey, metrics, properties);
        // attempt to store it (race other threads)
        HystrixMetricsPublisherThreadPool existing = threadPoolPublishers.putIfAbsent(threadPoolKey.name(), publisher);
        if (existing == null) {
            // we won the thread-race to store the instance we created so initialize it
            publisher.initialize();
            // done registering, return instance that got cached
            return publisher;
        } else {
            // we lost so return 'existing' and let the one we created be garbage collected
            // without calling initialize() on it
            return existing;
        }
    }