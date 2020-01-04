protected virtual IList<JObject> ExecuteQueryInternal(TableDefinition table, string sql, IDictionary<string, object> parameters)
        {
            table = table ?? new TableDefinition();
            parameters = parameters ?? new Dictionary<string, object>();
            var rows = new List<JObject>();

            sqlite3_stmt statement = SQLitePCLRawHelpers.GetSqliteStatement(sql, connection);
            using (statement)
            {
                foreach (KeyValuePair<string, object> parameter in parameters)
                {
                    var index = raw.sqlite3_bind_parameter_index(statement, parameter.Key);
                    SQLitePCLRawHelpers.Bind(connection, statement, index, parameter.Value);
                }
                int rc;
                while ((rc = raw.sqlite3_step(statement)) == raw.SQLITE_ROW)
                {
                    var row = ReadRow(table, statement);
                    rows.Add(row);
                }

                SQLitePCLRawHelpers.VerifySQLiteResponse(rc, raw.SQLITE_DONE, connection);
            }

            return rows;
        }