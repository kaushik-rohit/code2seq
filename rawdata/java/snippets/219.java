public V get(String key)
    {
        int index = exactMatchSearch(key);
        if (index >= 0)
        {
            return getValueAt(index);
        }

        return null;
    }