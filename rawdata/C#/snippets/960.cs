public static DbContextManager<C> GetManager(string database, string label, DbCompiledModel model)
    {
      lock (_lock)
      {
        var contextLabel = GetContextName(database, label);
        DbContextManager<C> mgr = null;
        if (ApplicationContext.LocalContext.Contains(contextLabel))
        {
          mgr = (DbContextManager<C>)(ApplicationContext.LocalContext[contextLabel]);
        }
        else
        {
          mgr = new DbContextManager<C>(database, label, model, null);
          mgr.ContextLabel = contextLabel;
          ApplicationContext.LocalContext[contextLabel] = mgr;
        }
        mgr.AddRef();
        return mgr;
      }
    }