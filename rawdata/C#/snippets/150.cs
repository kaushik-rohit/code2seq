public IAPIMapping<ClassType> SetPaged(Func<int, int, string, IEnumerable<ClassType>> Value)
        {
            PagedFunc = Value;
            return this;
        }