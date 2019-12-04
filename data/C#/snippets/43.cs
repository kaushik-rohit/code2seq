public void Cancel()
        {
            // If we're not null, assume we're executing
            if (_command != null)
                _command.Cancel();
        }