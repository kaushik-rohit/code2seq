public static async Task<LinkedServiceResource> GetAsync(this ILinkedServicesOperations operations, string resourceGroupName, string factoryName, string linkedServiceName, string ifNoneMatch = default(string), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetWithHttpMessagesAsync(resourceGroupName, factoryName, linkedServiceName, ifNoneMatch, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }