public IAPIMapping<ClassType> SetAll(Func<IEnumerable<ClassType>> Value)
        {
            AllFunc = Value;
            return this;
        }