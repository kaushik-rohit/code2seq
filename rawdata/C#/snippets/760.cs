public static Task<object[]> GetManyAsync(this ICacheConcurrencyStrategy cache, CacheKey[] keys, long timestamp, CancellationToken cancellationToken)
		{
			if (cancellationToken.IsCancellationRequested)
			{
				return Task.FromCanceled<object[]>(cancellationToken);
			}
			try
			{
				// PreferMultipleGet yields false if !IBatchableCacheConcurrencyStrategy, no GetMany call should be done
				// in such case.
				return ReflectHelper
				.CastOrThrow<IBatchableCacheConcurrencyStrategy>(cache, "batching")
				.GetManyAsync(keys, timestamp, cancellationToken);
			}
			catch (System.Exception ex)
			{
				return Task.FromException<object[]>(ex);
			}
		}