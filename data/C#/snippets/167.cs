public Task<IList<JObject>> ExecuteQueryAsync(string tableName, string sql, IDictionary<string, object> parameters)
        {
            if (tableName == null)
            {
                throw new ArgumentNullException("tableName");
            }
            if (sql == null)
            {
                throw new ArgumentNullException("sql");
            }

            this.EnsureInitialized();
            return this.operationSemaphore.WaitAsync()
                .ContinueWith(t =>
                {
                    try
                    {
                        return this.ExecuteQueryInternal(tableName, sql, parameters);
                    }
                    finally
                    {
                        this.operationSemaphore.Release();
                    }
                });
        }