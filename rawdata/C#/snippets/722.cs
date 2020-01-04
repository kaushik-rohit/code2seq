public static async Task<Microsoft.Rest.Azure.IPage<StorageInsight>> ListByWorkspaceAsync(this IStorageInsightsOperations operations, string resourceGroupName, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            {
                using (var _result = await operations.ListByWorkspaceWithHttpMessagesAsync(resourceGroupName, workspaceName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }