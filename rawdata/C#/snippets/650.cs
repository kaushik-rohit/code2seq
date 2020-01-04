public bool TryGet(out T item)
        {
            if (m_GlobalStack.TryPop(out item))
                return true;

            var currentSourceCount = m_CurrentSourceCount;

            if (currentSourceCount >= m_ItemsSource.Length)
            {
                return TryPopWithWait(out item, 100);
            }

            var isIncreasing = m_IsIncreasing;

            if (isIncreasing == 1)
                return TryPopWithWait(out item, 100);

            if (Interlocked.CompareExchange(ref m_IsIncreasing, 1, isIncreasing) != isIncreasing)
                return TryPopWithWait(out item, 100);

            IncreaseCapacity();

            m_IsIncreasing = 0;

            if (!m_GlobalStack.TryPop(out item))
            {
                return false;
            }

            return true;
        }