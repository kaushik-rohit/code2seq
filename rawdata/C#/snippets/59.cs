public FluentBuilder<T> For<T>(string typeAsCacheKey)
		{
			var concreteType = typeof(T);
			var details = new ConfigurationForType(concreteType, typeAsCacheKey);
			_details.Add(details);
			var fluentBuilder = new FluentBuilder<T>(this, _configuredTypes, details);
			return fluentBuilder;
		}