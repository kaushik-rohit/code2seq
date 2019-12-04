public instance TestableF0<T, [AssociatedType] R, implicit TestableT> : CTestable<Func<T>, R>
        where TestableT : CTestable<T, R>
    {
        string Name(Func<T> test) => test.Method?.Name ?? "(unnamed func)";
        TestResult<R> Test(Func<T> f, int depth) => TestableT.Test(f(), depth);
    }