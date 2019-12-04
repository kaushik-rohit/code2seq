public static DbContextManager<C> GetManager(ObjectContext context, string label)
    {
      lock (_lock)
      {
        var contextLabel = GetContextName(context.DefaultContainerName, label);
        DbContextManager<C> mgr = null;
        if (ApplicationContext.LocalContext.Contains(contextLabel))
        {
          mgr = (DbContextManager<C>)(ApplicationContext.LocalContext[contextLabel]);
        }
        else
        {
          mgr = new DbContextManager<C>(null, label, null, context);
          mgr.ContextLabel = contextLabel;
          ApplicationContext.LocalContext[contextLabel] = mgr;
        }
        mgr.AddRef();
        return mgr;
      }
    }