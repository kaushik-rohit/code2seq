public static async Task<LinkedServiceResource> CreateOrUpdateAsync(this ILinkedServicesOperations operations, string resourceGroupName, string factoryName, string linkedServiceName, LinkedServiceResource linkedService, string ifMatch = default(string), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.CreateOrUpdateWithHttpMessagesAsync(resourceGroupName, factoryName, linkedServiceName, linkedService, ifMatch, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }