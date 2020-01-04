@Read
    public Single<Map<String, Object>> getCaches() {
        return Flowable.fromIterable(cacheManager.getCacheNames())
                       .flatMapMaybe(n -> Flowable.fromPublisher(cacheManager.getCache(n).getCacheInfo()).firstElement())
                       .reduce(new HashMap<>(), (seed, info) -> {
                           seed.put(info.getName(), info.get());
                           return seed;
                       }).map(objectObjectHashMap -> Collections.singletonMap(
                           NAME, objectObjectHashMap
                       ));
    }