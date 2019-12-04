public Pattern Some(int max)
        {
            if (max < 0)
                throw new System.ArgumentException("max<0");
            if (max == 0)
                return Patterns.Always();
            return new SomePattern(max, this);
        }