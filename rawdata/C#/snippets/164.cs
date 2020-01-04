public override Task<JObject> LookupAsync(string tableName, string id)
        {
            if (tableName == null)
            {
                throw new ArgumentNullException("tableName");
            }
            if (id == null)
            {
                throw new ArgumentNullException("id");
            }

            this.EnsureInitialized();

            string sql = string.Format("SELECT * FROM {0} WHERE {1} = @id", SqlHelpers.FormatTableName(tableName), MobileServiceSystemColumns.Id);
            var parameters = new Dictionary<string, object>
            {
                {"@id", id}
            };

            return this.operationSemaphore.WaitAsync()
                .ContinueWith(t =>
                {
                    try
                    {
                        IList<JObject> results = this.ExecuteQueryInternal(tableName, sql, parameters);
                        return results.FirstOrDefault();
                    }
                    finally
                    {
                        this.operationSemaphore.Release();
                    }
                });
        }