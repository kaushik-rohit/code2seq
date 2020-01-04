[NotNull]
        public static IrbisAlphabetTable GetInstance
            (
                [NotNull] ManagedClient64 connection
            )
        {
            if (ReferenceEquals(_instance, null))
            {
                lock (_lock)
                {
                    if (ReferenceEquals(_instance, null))
                    {
                        _instance = new IrbisAlphabetTable(connection);
                    }
                }
            }

            return _instance;
        }