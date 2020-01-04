internal void CheckIn(ObjectPoolSegment<T> owningSegment, T instance)
        {
            lock (_syncRoot)
            {
                owningSegment.CheckInObject(instance);
            }
        }