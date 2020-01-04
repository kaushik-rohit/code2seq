public IAPIMapping<ClassType> SetCanSave(Func<ClassType, bool> Value)
        {
            CanSaveFunc = Value;
            return this;
        }