public instance TestableF1<A, T, [AssociatedType] R, implicit SerialA, implicit TestableT> : CTestable<Func<A, T>, F1Trace<A, R>>
        where SerialA : CSerial<A>
        where TestableT : CTestable<T, R>
    {
        string Name(Func<A, T> test) => test.Method?.Name ?? "(unnamed func)";

        TestResult<F1Trace<A, R>> Test(Func<A, T> f, int depth)
        {
            var result = new TestResult<F1Trace<A, R>> {};
            foreach (var a in SerialA.Series(depth))
            {
                result.Merge(TestableT.Test(f(a), depth), (w) => new F1Trace<A, R> { input = a, next = w });
                if (result.Failed)
                {
                    break;
                }
            }

            return result;
        }
    }