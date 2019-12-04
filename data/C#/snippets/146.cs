public IAPIMapping<ClassType> SetCanGet(Func<ClassType, bool> Value)
        {
            CanGetFunc = Value;
            return this;
        }