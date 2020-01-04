public void setStatus(String asgName, boolean enabled) {
        String asgAccountId = getASGAccount(asgName);
        asgCache.put(new CacheKey(asgAccountId, asgName), enabled);
    }