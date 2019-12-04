public IModule QueryModule<T1>(Type moduleType, T1 query)
        {
            if (moduleType == typeof(TIntf))
            {
                if (_filter?.CheckQuery(query) ?? true)
                {
                    return _module;
                }
            }
            return null;
        }