protected virtual IList<JObject> ExecuteQueryInternal(string tableName, string sql, IDictionary<string, object> parameters)
        {
            TableDefinition table = GetTable(tableName);
            return this.ExecuteQueryInternal(table, sql, parameters);
        }