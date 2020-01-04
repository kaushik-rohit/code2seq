public override bool InsertRow(string table, Row row)
        {
            StringBuilder sql = new StringBuilder();
            lock(DatabaseLock)
            {
                try
                {
                    if (!IsConnected)
                    {
                        Syslog.DebugLog("Postponing request to insert a row into database which is not connected");
                        lock(unwritten.PendingRows)
                        {
                            unwritten.PendingRows.Add(new SerializedRow(table, row));
                        }
                        FlushRows();
                        return false;
                    }

                    MySqlCommand mySqlCommand = Connection.CreateCommand();
                    sql.Append("INSERT INTO ");
                    sql.Append(table);
                    sql.Append(" VALUES (");
                    foreach (Row.Value value in row.Values)
                    {
                        switch (value.Type)
                        {
                            case DataType.Boolean:
                            case DataType.Integer:
                                sql.Append(value.Data);
                                sql.Append(", ");
                                break;
                            case DataType.Varchar:
                            case DataType.Text:
                            case DataType.Date:
                                sql.Append("'");
                                sql.Append(MySqlHelper.EscapeString(value.Data));
                                sql.Append("', ");
                                break;
                        }
                    }
                    if (sql.ToString().EndsWith(", "))
                    {
                        sql.Remove(sql.Length - 2, 2);
                    }
                    sql.Append(");");
                    mySqlCommand.CommandText = sql.ToString();
                    mySqlCommand.ExecuteNonQuery();
                    return true;
                } catch (MySqlException me)
                {
                    ErrorBuffer = me.Message;
                    Syslog.Log("Error while storing a row to DB " + me, true);
                    Syslog.DebugLog("SQL: " + sql);
                    lock(unwritten.PendingRows)
                    {
                        unwritten.PendingRows.Add(new SerializedRow(table, row));
                    }
                    FlushRows();
                    return false;
                }
            }
        }