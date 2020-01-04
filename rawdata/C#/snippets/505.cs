public RetriableFunctionAsync<T> UntilNotNull()
        {
            untilValids.Add(value => value != null);

            return this;
        }