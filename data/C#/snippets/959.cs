public async Task Retry<TException>(Action action, Action resetState, CancellationToken? canceler = null)
            where TException : Exception
        {
            await Retry<TException, bool>(
                () => { action?.Invoke(); return true; }, resetState, canceler)
                .ConfigureAwait(false);
        }