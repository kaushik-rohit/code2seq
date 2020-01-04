private int transfer(int state, int[] ids)
    {
        for (int c : ids)
        {
            if ((getBase(state) + c < getBaseArraySize())
                && (getCheck(getBase(state) + c) == state))
            {
                state = getBase(state) + c;
            }
            else
            {
                return -1;
            }
        }
        return state;
    }