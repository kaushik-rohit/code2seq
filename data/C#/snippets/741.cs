protected override void Dispose(bool disposing)
        {
            if (!m_disposed)
            {
                try
                {
                    if (disposing)
                    {
                        if (m_mongo != null)
                            m_mongo.Dispose();

                        m_mongo = null;

                        if (m_timer != null)
                            m_timer.Dispose();

                        m_timer = null;
                    }
                }
                finally
                {
                    m_disposed = true;          // Prevent duplicate dispose.
                    base.Dispose(disposing);    // Call base class Dispose().
                }
            }
        }