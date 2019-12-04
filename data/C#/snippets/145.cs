public IAPIMapping<ClassType> SetCanDelete(Func<ClassType, bool> Value)
        {
            CanDeleteFunc = Value;
            return this;
        }