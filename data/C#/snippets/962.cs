public async Task<TResult> Retry<TException, TResult>(
            Func<TResult> action, Action resetState, CancellationToken? canceler = null)
            where TException : Exception
        {
            if (action == null) throw new ArgumentNullException(nameof(action));

            Stopwatch watch = Stopwatch.StartNew();
            for (int i = 1; true; i++)
            {
                try
                {
                    return action.Invoke();
                }
                catch (TException error)
                {
                    resetState?.Invoke();
                    await DelayOrFault(watch.Elapsed, i, canceler, error).ConfigureAwait(false);
                }
            }
        }