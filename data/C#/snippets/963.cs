private async Task<bool> DelayIfNotDone(TimeSpan elapsed, int tries, CancellationToken? canceler)
        {
            if (tries < m_Tries && elapsed < m_Timeout)
            {
                await DelayOrCancel(canceler).ConfigureAwait(false);
                return true;
            }
            else
            {
                return false;
            }
        }