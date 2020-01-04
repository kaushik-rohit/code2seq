internal IDiskStorage Get()
        {
            lock (_diskInstanceGate)
            {
                if (ShouldCreateNewStorage())
                {
                    // Discard anything we created
                    DeleteOldStorageIfNecessary();
                    CreateStorage();
                }

                return Preconditions.CheckNotNull(_currentState.DiskStorageDelegate);
            }
        }