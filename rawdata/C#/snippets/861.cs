public Order GetDetails()
        {
            lock (this)
            {
                return LastOrderStats;
            }
        }