public Pattern Some(int min, int max)
        {
            if (min < 0 || max < 0 || min > max)
                throw new System.ArgumentException();
            if (max == 0)
                return Patterns.Always();
            return new SomeMinPattern(min, this, max);
        }