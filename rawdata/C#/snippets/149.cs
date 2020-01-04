public IAPIMapping<ClassType> SetPageCount(Func<int, int> Value)
        {
            this.PageCountFunc = Value;
            return this;
        }