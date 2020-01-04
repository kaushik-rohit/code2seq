public IAPIMapping<ClassType> SetSave(Func<ClassType, bool> Value)
        {
            SaveFunc = Value;
            return this;
        }