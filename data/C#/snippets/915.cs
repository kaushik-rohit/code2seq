[NotNull]
        [ItemNotNull]
        public string[] SplitWords
        (
            [CanBeNull] string text
        )
        {
            if (string.IsNullOrEmpty(text))
            {
                return new string[0];
            }

            List<string> result = new List<string>();
            StringBuilder accumulator = new StringBuilder();

            foreach (char c in text)
            {
                if (IsAlpha(c))
                {
                    accumulator.Append(c);
                }
                else
                {
                    if (accumulator.Length != 0)
                    {
                        result.Add(accumulator.ToString());
                        accumulator.Length = 0;
                    }
                }
            }

            if (accumulator.Length != 0)
            {
                result.Add(accumulator.ToString());
            }

            return result.ToArray();
        }