protected virtual void ExecuteNonQueryInternal(string sql, IDictionary<string, object> parameters)
        {
            parameters = parameters ?? new Dictionary<string, object>();

            sqlite3_stmt stmt;
            int rc = raw.sqlite3_prepare_v2(connection, sql, out stmt);
            SQLitePCLRawHelpers.VerifySQLiteResponse(rc, raw.SQLITE_OK, connection);
            using (stmt)
            {
                foreach (KeyValuePair<string, object> parameter in parameters)
                {
                    var index = raw.sqlite3_bind_parameter_index(stmt, parameter.Key);
                    SQLitePCLRawHelpers.Bind(connection, stmt, index, parameter.Value);
                }

                int result = raw.sqlite3_step(stmt);
                SQLitePCLRawHelpers.VerifySQLiteResponse(result, raw.SQLITE_DONE, connection);
            }
        }