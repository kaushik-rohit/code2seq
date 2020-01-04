public static void clear(ObjectReader reader, final CacheScope scope) {
        withCache(reader, cache -> {
            if (scope == CacheScope.GLOBAL_SCOPE) {
                if (debugLogEnabled)
                    logger.debug("clearing global-level cache with size {}", cache.globalCache.size());
                cache.globalCache.clear();
            }
            if (debugLogEnabled)
                logger.debug("clearing app-level serialization cache with size {}", cache.applicationCache.size());
            cache.applicationCache.clear();
            return null;
        });
    }