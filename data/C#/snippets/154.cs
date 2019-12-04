public override Task<JToken> ReadAsync(MobileServiceTableQueryDescription query)
        {
            if (query == null)
            {
                throw new ArgumentNullException("query");
            }

            this.EnsureInitialized();

            var formatter = new SqlQueryFormatter(query);
            string sql = formatter.FormatSelect();

            return this.operationSemaphore.WaitAsync()
                .ContinueWith(t =>
                {
                    try
                    {
                        IList<JObject> rows = this.ExecuteQueryInternal(query.TableName, sql, formatter.Parameters);
                        JToken result = new JArray(rows.ToArray());

                        if (query.IncludeTotalCount)
                        {
                            sql = formatter.FormatSelectCount();
                            IList<JObject> countRows = null;

                            countRows = this.ExecuteQueryInternal(query.TableName, sql, formatter.Parameters);


                            long count = countRows[0].Value<long>("count");
                            result = new JObject()
                            {
                                { "results", result },
                                { "count", count }
                            };
                        }

                        return result;
                    }
                    finally
                    {
                        this.operationSemaphore.Release();
                    }
                });
        }