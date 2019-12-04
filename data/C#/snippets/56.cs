public IMbCacheFactory BuildFactory()
		{
			checkAllImplementationAndMethodsAreOk();
			if (_cache == null)
			{
				_cache = new InMemoryCache(20);
			}
			setCacheKeysAndInit();
			var events = new EventListenersCallback(_eventListeners);
			_cache.Initialize(events);
			return new MbCacheFactory(_proxyFactory, new CacheAdapter(_cache), _configuredTypes);
		}