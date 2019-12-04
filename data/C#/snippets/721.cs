public static async System.Threading.Tasks.Task<StorageInsight> GetAsync(this IStorageInsightsOperations operations, string resourceGroupName, string workspaceName, string storageInsightName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            {
                using (var _result = await operations.GetWithHttpMessagesAsync(resourceGroupName, workspaceName, storageInsightName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }