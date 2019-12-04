public void Dispose()
        {
            if (_disposed)
                return;

            _disposed = true;
            _owningObjectPool.CheckIn(_owningSegment, _instance);
            GC.SuppressFinalize(this);
        }