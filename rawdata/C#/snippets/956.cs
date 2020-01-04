public async Task<IReadOnlyCollection<T>> Repeat<T>(Func<T> action, CancellationToken? canceler = null)
        {
            if (action == null) throw new ArgumentNullException(nameof(action));

            List<T> results = new List<T>();

            Stopwatch watch = Stopwatch.StartNew();
            int attempt = 0;
            do
            {
                results.Add(action.Invoke());
            } while (await DelayIfNotDone(watch.Elapsed, ++attempt, canceler).ConfigureAwait(false));

            return results.AsReadOnly();
        }