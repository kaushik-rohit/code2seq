public string Generate()
        {
            var pool = string.IsNullOrEmpty(this.CharactersPool) ? CreateCharactersPool() : this.CharactersPool.ToCharArray();
            var sb = new StringBuilder(PasswordLength);

            if (this.GeneratorFlags.HasFlag(GeneratorFlag.ShuffleChars))
            {
                ShuffleCharsArray(pool);
            }

            for (int i = 0; i < PasswordLength; i++)
            {
                int random = GetNextRandom(pool.Length);
                sb.Append(pool[random]);
            }

            return sb.ToString();
        }