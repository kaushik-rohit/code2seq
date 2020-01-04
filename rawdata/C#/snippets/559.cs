public override void Connect()
        {
            lock (DatabaseLock)
            {
                if (IsConnected)
                {
                    return;
                }
                try
                {
                    Connection = new MySqlConnection("Server=" + Configuration.MySQL.MysqlHost + ";" +
                                                                              "Database=" + Configuration.MySQL.Mysqldb + ";" +
                                                                              "User ID=" + Configuration.MySQL.MysqlUser + ";" +
                                                                              "Password=" + Configuration.MySQL.MysqlPw + ";" +
                                                                              "port=" + Configuration.MySQL.MysqlPort + ";" +
                                                                              "CharSet=utf8;" +
                                                                              "Pooling=false");
                    Connection.Open();
                    connected = true;
                }
                catch (MySqlException ex)
                {
                    Syslog.Log("MySQL: Unable to connect to server: " + ex, true);
                    connected = false;
                }
            }
        }