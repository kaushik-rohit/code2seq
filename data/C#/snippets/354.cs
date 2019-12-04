public static ICacheProvider SetCacheProvider(string providerType)
        {
            lock (syncProvider)
            {
                cacheProvider = ActivateProvider(providerType);
                return cacheProvider;
            }
        }