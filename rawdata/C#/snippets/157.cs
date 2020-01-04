public override Task DeleteAsync(MobileServiceTableQueryDescription query)
        {
            if (query == null)
            {
                throw new ArgumentNullException("query");
            }

            this.EnsureInitialized();

            var formatter = new SqlQueryFormatter(query);
            string sql = formatter.FormatDelete();

            return this.operationSemaphore.WaitAsync()
                .ContinueWith(t =>
                {
                    try
                    {
                        this.ExecuteNonQueryInternal(sql, formatter.Parameters);
                    }
                    finally
                    {
                        this.operationSemaphore.Release();
                    }
                });
        }