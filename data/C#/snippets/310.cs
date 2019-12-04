public IAsyncResult BeginExecute(AsyncCallback callback, object state)
        {
            //  Prevent from executing BeginExecute before calling EndExecute
            if (this._asyncResult != null)
            {
                throw new InvalidOperationException("Asynchronous operation is already in progress.");
            }

            //  Create new AsyncResult object
            this._asyncResult = new CommandAsyncResult(this)
            {
                AsyncWaitHandle = new ManualResetEvent(false),
                IsCompleted = false,
                AsyncState = state,
            };

            //  When command re-executed again, create a new channel
            if (this._channel != null)
            {
                throw new SshException("Invalid operation.");
            }

            this.CreateChannel();

            if (string.IsNullOrEmpty(this.CommandText))
                throw new ArgumentException("CommandText property is empty.");

            this._callback = callback;

            this._channel.Open();

            //  Send channel command request
            this._channel.SendExecRequest(this.CommandText);

            return _asyncResult;
        }