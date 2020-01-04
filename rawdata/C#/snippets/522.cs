public instance TestableLazy<T, [AssociatedType] R, implicit TestableT> : CTestable<Lazy<T>, R>
        where TestableT : CTestable<T, R>
    {
        // We don't want to evaluate the test prematurely!
        string Name(Lazy<T> test) => test.IsValueCreated ? TestableT.Name(test.Value) : "(delayed test)";
        TestResult<R> Test(Lazy<T> test, int depth) => TestableT.Test(test.Value, depth);
    }