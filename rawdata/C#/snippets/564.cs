public static void RecursivelyLogException(Logger logger, Exception e)
        {
            if(logger == null || e == null)
            {
                // Let's not throw here, just return.
                Debug.WriteLine(string.Format("In {0}::{1}, parameters are null, returning without operation.", nameof(LoggerUtil), nameof(RecursivelyLogException)));
                return;
            }

            while(e != null)
            {
                logger.Error(e.Message);
                logger.Error(e.StackTrace);

                Debug.WriteLine(e.Message);
                Debug.WriteLine(e.StackTrace);

                e = e.InnerException;
            }
        }