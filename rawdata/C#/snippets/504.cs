public RetriableFunctionAsync<T> Until(Func<T, bool> isValid)
        {
            if (isValid == null)
            {
                throw new ArgumentNullException("isValid");
            }

            untilValids.Add(isValid);

            return this;
        }