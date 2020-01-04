public Pattern Many(int min)
        {
            if (min < 0)
                throw new System.ArgumentException("min<0");
            return new ManyMinPattern(min, this);
        }