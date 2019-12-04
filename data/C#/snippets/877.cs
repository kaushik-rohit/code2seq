public virtual decimal GetSlippageApproximation(Security asset, Order order)
        {
            var lastData = asset.GetLastData();
            var lastTick = lastData as Tick;

            // if we have tick data use the spread
            if (lastTick != null)
            {
                if (order.Direction == OrderDirection.Buy)
                {
                    //We're buying, assume slip to Asking Price.
                    return Math.Abs(order.Price - lastTick.AskPrice);
                }
                if (order.Direction == OrderDirection.Sell)
                {
                    //We're selling, assume slip to the bid price.
                    return Math.Abs(order.Price - lastTick.BidPrice);
                }
            }

            return 0m;
        }