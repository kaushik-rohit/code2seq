private async Task DelayOrCancel(CancellationToken? canceler)
        {
            CancellationToken token = canceler ?? CancellationToken.None;
            if (m_Delay > TimeSpan.Zero)
            {
                await Task.Delay(m_Delay, token).ConfigureAwait(false);
            }
            else
            {
                token.ThrowIfCancellationRequested();
            }
        }