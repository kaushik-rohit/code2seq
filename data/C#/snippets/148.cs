public IAPIMapping<ClassType> SetDelete(Func<ClassType, bool> Value)
        {
            DeleteFunc = Value;
            return this;
        }