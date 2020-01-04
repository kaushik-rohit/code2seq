public IDictionary<string, object> GetChangedProperties()
		{
			if(_changedProperties == null)
				System.Threading.Interlocked.CompareExchange(ref _changedProperties, new ConcurrentDictionary<string, object>(), null);

			return _changedProperties;
		}