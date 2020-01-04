public async Task<T> Now()
        {
            var attempt = 0L;

            while (true)
            {
                try
                {
                    var result = await operation();

                    if (!untilValids.Any() || untilValids.Any(isValid => isValid(result)))
                    {
                        return result;
                    }

                    if (attempt >= maxRetries)
                    {
                        throw new TimeoutException($"Execution timed out after {maxRetries} attempts.");
                    }
                }
                catch (Exception ex)
                {
                    report(ex);

                    var shouldThrow = exceptionsToThrowOn.Any(t => t.IsInstanceOfType(ex));

                    // If there are no exception handlers then handle all exceptions by default
                    var shouldHandle = !exceptionsToRetryOn.Any() ||
                                       exceptionsToRetryOn.Any(t => t.IsInstanceOfType(ex));

                    if (shouldThrow || !shouldHandle)
                    {
                        throw;
                    }

                    if (attempt >= maxRetries)
                    {
                        throw;
                    }
                }

                var delay = getDelay(attempt++);
                await Task.Delay(delay);
            }
        }