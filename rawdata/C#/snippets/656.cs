public IObservable<PagesBuild> GetAll(long repositoryId, ApiOptions options)
        {
            Ensure.ArgumentNotNull(options, nameof(options));

            return _connection.GetAndFlattenAllPages<PagesBuild>(ApiUrls.RepositoryPageBuilds(repositoryId), options);
        }