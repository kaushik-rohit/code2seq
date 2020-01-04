private int resize(int newSize)
    {
        int[] base2 = new int[newSize];
        int[] check2 = new int[newSize];
        if (allocSize > 0)
        {
            System.arraycopy(base, 0, base2, 0, allocSize);
            System.arraycopy(check, 0, check2, 0, allocSize);
        }

        base = base2;
        check = check2;

        return allocSize = newSize;
    }