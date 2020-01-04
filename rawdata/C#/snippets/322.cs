public void CancelAsync()
        {
            if (this._channel != null && this._channel.IsOpen && this._asyncResult != null)
            {
                this._channel.Close();
            }
        }