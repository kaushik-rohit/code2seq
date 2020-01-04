public IAsyncResult BeginExecute(string commandText, AsyncCallback callback, object state)
        {
            this.CommandText = commandText;

            return BeginExecute(callback, state);
        }