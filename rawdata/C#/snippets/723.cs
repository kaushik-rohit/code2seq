public static async Task<Microsoft.Rest.Azure.IPage<StorageInsight>> ListByWorkspaceNextAsync(this IStorageInsightsOperations operations, string nextPageLink, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            {
                using (var _result = await operations.ListByWorkspaceNextWithHttpMessagesAsync(nextPageLink, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }