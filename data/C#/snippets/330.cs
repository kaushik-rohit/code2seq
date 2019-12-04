protected virtual void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called.
            if (!this._isDisposed)
            {
                // If disposing equals true, dispose all managed
                // and unmanaged ResourceMessages.
                if (disposing)
                {

                    this._session.Disconnected -= Session_Disconnected;
                    this._session.ErrorOccured -= Session_ErrorOccured;

                    // Dispose managed ResourceMessages.
                    if (this.OutputStream != null)
                    {
                        this.OutputStream.Dispose();
                        this.OutputStream = null;
                    }

                    // Dispose managed ResourceMessages.
                    if (this.ExtendedOutputStream != null)
                    {
                        this.ExtendedOutputStream.Dispose();
                        this.ExtendedOutputStream = null;
                    }

                    // Dispose managed ResourceMessages.
                    if (this._sessionErrorOccuredWaitHandle != null)
                    {
                        this._sessionErrorOccuredWaitHandle.Dispose();
                        this._sessionErrorOccuredWaitHandle = null;
                    }

                    // Dispose managed ResourceMessages.
                    if (this._channel != null)
                    {
                        this._channel.DataReceived -= Channel_DataReceived;
                        this._channel.ExtendedDataReceived -= Channel_ExtendedDataReceived;
                        this._channel.RequestReceived -= Channel_RequestReceived;
                        this._channel.Closed -= Channel_Closed;

                        this._channel.Dispose();
                        this._channel = null;
                    }
                }

                // Note disposing has been done.
                this._isDisposed = true;
            }
        }