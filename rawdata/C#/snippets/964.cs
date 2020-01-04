private async Task DelayOrFault(TimeSpan elapsed, int tries, CancellationToken? canceler, Exception ex = null)
        {
            if (tries >= m_Tries)
            {
                throw new TimeoutException($"Reached max attempts of '{m_Tries}'.", ex);
            }
            else if (elapsed >= m_Timeout)
            {
                throw new TimeoutException($"Reached timeout of '{m_Timeout}'.", ex);
            }
            else
            {
                await DelayOrCancel(canceler).ConfigureAwait(false);
            }
        }