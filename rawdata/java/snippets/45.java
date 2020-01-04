public LocalCachedMapOptions<K, V> evictionPolicy(EvictionPolicy evictionPolicy) {
        if (evictionPolicy == null) {
            throw new NullPointerException("evictionPolicy can't be null");
        }
        this.evictionPolicy = evictionPolicy;
        return this;
    }