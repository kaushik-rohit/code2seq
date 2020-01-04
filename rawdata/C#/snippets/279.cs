public override string ResolveAssemblyFromClass(
            string className
            )
        {
            // search through the well-known assemblies
            for (int i = 0; i < __WellKnownAssemblies.Length; i++)
            {
                if (__WellKnownAssemblies[i] == null)
                {
                    __WellKnownAssemblies[i] = Assembly.Load(
                        GetCompatibleAssemblyName(__WellKnownAssemblyNames[i])
                        );
                }

                if (__WellKnownAssemblies[i] != null && __WellKnownAssemblies[i].GetType(className) != null)
                {
                    return __WellKnownAssemblies[i].GetName().FullName;
                }
            }

            // search through the custom assemblies
            if (__Assemblies != null)
            {
                foreach (KeyValuePair<string, Assembly> pair in __Assemblies)
                {
                    if (pair.Value.GetType(className) != null)
                    {
                        return pair.Value.GetName().FullName;
                    }
                }
            }

            return null;
        }