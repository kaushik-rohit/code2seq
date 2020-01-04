public async Task<ResponseWrapper<Commit>> Get(string projectKey, string repositorySlug, RequestOptions requestOptions = null, RequestOptionsForCommits commitRequestOptions = null)
        {
            string requestUrl = UrlBuilder.FormatRestApiUrlWithCommitOptions(MANY_COMMITS, requestOptions, commitRequestOptions, projectKey, repositorySlug);

            ResponseWrapper<Commit> response = await _httpWorker.GetAsync<ResponseWrapper<Commit>>(requestUrl).ConfigureAwait(false);

            return response;
        }