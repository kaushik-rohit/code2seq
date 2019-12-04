public async Task<IReadOnlyCollection<T>> StallUntil<T>(
            Func<T> action, Func<bool> checkState, CancellationToken? canceler = null)
        {
            if (action == null) throw new ArgumentNullException(nameof(checkState));
            if (checkState == null) throw new ArgumentNullException(nameof(checkState));

            List<T> results = new List<T>();

            Stopwatch watch = Stopwatch.StartNew();
            for (int i = 1; true; i++)
            {
                results.Add(action.Invoke());
                if (checkState.Invoke())
                {
                    break;
                }
                else
                {
                    await DelayOrFault(watch.Elapsed, i, canceler).ConfigureAwait(false);
                }
            }

            return results.AsReadOnly();
        }