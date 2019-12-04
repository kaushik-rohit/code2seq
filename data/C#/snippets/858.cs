public void SetMaximalPrice(double NewMaxPrice)
        {
            lock (this)
            {
                MaxPrice = NewMaxPrice;
            }
        }