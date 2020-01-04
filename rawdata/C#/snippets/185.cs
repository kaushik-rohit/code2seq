public void PurgeUnexpectedResources()
        {
            try
            {
                Get().PurgeUnexpectedResources();
            }
            catch (IOException)
            {
                // this method in fact should throu IOException
                // for now we will swallow the exception as it's done in DefaultDiskStorage
                Debug.WriteLine("purgeUnexpectedResources");
            }
        }