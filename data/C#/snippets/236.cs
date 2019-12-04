public static async Task<IPage<LinkedServiceResource>> ListByFactoryAsync(this ILinkedServicesOperations operations, string resourceGroupName, string factoryName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListByFactoryWithHttpMessagesAsync(resourceGroupName, factoryName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }