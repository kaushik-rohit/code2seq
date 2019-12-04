public void Stop(bool RemoveOrder)
        {
            lock (this)
            {
                if (RemoveOrder && OrderID != 0)
                    APIWrapper.OrderRemove(ServiceLocation, Algorithm, OrderID);

                CanRun = false;
            }

            OrderThread.Join();
        }