public void SetLimit(double Limit)
        {
            lock (this)
            {
                StartLimit = Limit;
            }
        }