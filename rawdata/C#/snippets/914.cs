public static void ResetInstance()
        {
            lock (_lock)
            {
                _instance = null;
            }
        }