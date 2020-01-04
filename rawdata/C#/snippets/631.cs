public void SetCharactersPool(string pool)
        {
            if (string.IsNullOrEmpty(pool))
            {
                throw new ArgumentException(Properties.Strings.CharactersPoolEmpty);
            }
            this.CharactersPool = pool;
        }