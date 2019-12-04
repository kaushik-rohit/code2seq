public static async System.Threading.Tasks.Task<StorageInsight> CreateOrUpdateAsync(this IStorageInsightsOperations operations, string resourceGroupName, string workspaceName, string storageInsightName, StorageInsight parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            {
                using (var _result = await operations.CreateOrUpdateWithHttpMessagesAsync(resourceGroupName, workspaceName, storageInsightName, parameters, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }