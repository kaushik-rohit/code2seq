public IAPIMapping<ClassType> SetAny(Func<string, ClassType> Value)
        {
            AnyFunc = Value;
            return this;
        }