public static async Task<bool[]> PutManyAsync(this ICacheConcurrencyStrategy cache, CacheKey[] keys, object[] values, long timestamp,
		                          object[] versions, IComparer[] versionComparers, bool[] minimalPuts, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			if (cache is IBatchableCacheConcurrencyStrategy batchableCache)
			{
				return await (batchableCache.PutManyAsync(keys, values, timestamp, versions, versionComparers, minimalPuts, cancellationToken)).ConfigureAwait(false);
			}

			var result = new bool[keys.Length];
			for (var i = 0; i < keys.Length; i++)
			{
				result[i] = await (cache.PutAsync(keys[i], values[i], timestamp, versions[i], versionComparers[i], minimalPuts[i], cancellationToken)).ConfigureAwait(false);
			}

			return result;
		}