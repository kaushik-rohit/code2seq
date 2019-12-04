public static bool HasNOrMoreOccurancesOfChar(this string str, int n, char c)
        {
            int count = 0;
            for (int i = 0; i < str.Length || count >= n; i++)
            {
                if (str[i] == c)
                {
                    count++;
                }
            }
            return count >= n;
        }