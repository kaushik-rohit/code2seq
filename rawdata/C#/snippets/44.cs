public DataSet Execute()
        {
            string queryText;
            DataSet dataSet = new DataSet();

            // Set integrated security option
            if (this.Username == null)
                _builder.IntegratedSecurity = true;

            // Build query
            if (this.InputFile == null)
                queryText = System.IO.File.ReadAllText(this.InputFile);
            else
                queryText = this.Query;

            // Create connection
            using (SqlConnection connection = new SqlConnection(_builder.ConnectionString))
            using (_command = new SqlCommand(queryText, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(_command))
            {
                // Add print statement handler
                connection.FireInfoMessageEventOnUserErrors = true;
                connection.InfoMessage += this.InfoMessageEventHandler;

                // Set command properties
                _command.CommandTimeout = this.CommandTimeout;
                _command.CommandType = CommandType.Text;

                // Add parameters
                foreach (KeyValuePair<string, object> parameter in this.Parameters)
                    _command.Parameters.AddWithValue(parameter.Key, parameter.Value);

                // Open connection
                connection.Open();

                // Execute statement and fill dataset
                adapter.Fill(dataSet);

                // Close the connection
                connection.Close();
            }

            // Lets set it to null so we know it's been disposed
            _command = null;

            return dataSet;
        }