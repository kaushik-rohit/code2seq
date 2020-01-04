[__DynamicallyInvokable]
    protected virtual void Dispose(bool disposing)
    {
      int id;
      lock (ThreadLocal<T>.s_idManager)
      {
        id = ~this.m_idComplement;
        this.m_idComplement = 0;
        if (id < 0 || !this.m_initialized)
          return;
        this.m_initialized = false;
        for (ThreadLocal<T>.LinkedSlot local_1 = this.m_linkedSlot.Next; local_1 != null; local_1 = local_1.Next)
        {
          ThreadLocal<T>.LinkedSlotVolatile[] local_2 = local_1.SlotArray;
          if (local_2 != null)
          {
            local_1.SlotArray = (ThreadLocal<T>.LinkedSlotVolatile[]) null;
            local_2[id].Value.Value = default (T);
            local_2[id].Value = (ThreadLocal<T>.LinkedSlot) null;
          }
        }
      }
      this.m_linkedSlot = (ThreadLocal<T>.LinkedSlot) null;
      ThreadLocal<T>.s_idManager.ReturnId(id);
    }