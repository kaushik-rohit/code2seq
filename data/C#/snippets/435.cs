public object Get(string key)
        {
            lock (this)
            {
                if (m_map == null)
                    return null;
                else
                    return m_map[key];
            }
        }