public IObservable<PagesBuild> RequestPageBuild(string owner, string name)
        {
            Ensure.ArgumentNotNullOrEmptyString(owner, nameof(owner));
            Ensure.ArgumentNotNullOrEmptyString(name, nameof(name));

            return _client.RequestPageBuild(owner, name).ToObservable();
        }