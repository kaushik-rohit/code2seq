public double GetEntropy()
        {
            var pool = string.IsNullOrEmpty(this.CharactersPool) ? CreateCharactersPool() : this.CharactersPool.ToCharArray();
            return Math.Log(Math.Pow(this.PasswordLength, pool.Length), 2);
        }