public Pattern Repeat(int n)
        {
            if (n == 0)
                return Patterns.Always();
            if (n == 1)
                return this;
            return new RepeatPattern(n, this);
        }