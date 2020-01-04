[__DynamicallyInvokable]
    public void Dispose()
    {
      this.Dispose(true);
      GC.SuppressFinalize((object) this);
    }