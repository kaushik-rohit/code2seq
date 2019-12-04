public bool Equals(Limiter other)
        {
            return other != null
                && m_Delay == other.m_Delay
                && m_Timeout == other.m_Timeout
                && m_Tries == other.m_Tries;
        }