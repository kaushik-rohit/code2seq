@VisibleForTesting
    void removeAllCacheEntries() {
        List<CacheEntry> entries;
        synchronized (this.cacheEntries) {
            entries = new ArrayList<>(this.cacheEntries.values());
            this.cacheEntries.clear();
        }

        removeFromCache(entries);
        if (entries.size() > 0) {
            log.debug("{}: Cleared all cache entries ({}).", this.traceObjectId, entries.size());
        }
    }