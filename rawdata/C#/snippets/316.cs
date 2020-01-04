public string EndExecute(IAsyncResult asyncResult)
        {
            if (this._asyncResult == asyncResult && this._asyncResult != null)
            {
                lock (this._endExecuteLock)
                {
                    if (this._asyncResult != null)
                    {
                        //  Make sure that operation completed if not wait for it to finish
                        this.WaitHandle(this._asyncResult.AsyncWaitHandle);

                        if (this._channel.IsOpen)
                        {
                            this._channel.SendEof();

                            this._channel.Close();
                        }

                        this._channel = null;

                        this._asyncResult = null;

                        return this.Result;
                    }
                }
            }

            throw new ArgumentException("Either the IAsyncResult object did not come from the corresponding async method on this type, or EndExecute was called multiple times with the same IAsyncResult.");
        }