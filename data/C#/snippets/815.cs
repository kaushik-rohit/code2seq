public static void RegisterMaxNodeFactory(IMaxNodeFactory factory)
      {
         Throw.IfNull(factory, "factory");

         if (maxNodeFactories == null)
            maxNodeFactories = new List<IMaxNodeFactory>();

         maxNodeFactories.Add(factory);
      }