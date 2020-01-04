public static ICacheProvider GetCacheProvider()
        {
            if(cacheProvider != null) return cacheProvider;

            lock (syncProvider)
            {
                var providerType = ConfigurationManager.AppSettings[PROVIDER_CONFIG];
                if (providerType == null) return null;

                cacheProvider = ActivateProvider(providerType);
                return cacheProvider;
            }
        }