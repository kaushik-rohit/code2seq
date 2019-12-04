protected virtual void Dispose(bool disposing)
        {
            if (disposed) return;

            lock (this)
            {
                if (disposed) return;

                if (disposing)
                {
                    if (EndpointHost.Config != null && EndpointHost.Config.ServiceManager != null)
                    {
                        EndpointHost.Config.ServiceManager.Dispose();
                    }

                    EndpointHost.Dispose();
                }

                //release unmanaged resources here...
                disposed = true;
            }
        }