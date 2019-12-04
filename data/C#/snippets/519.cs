public instance TestableF2<A, B, T, [AssociatedType] R, implicit SerialA, implicit SerialB, implicit TestableT> : CTestable<Func<A, B, T>, F2Trace<A, B, R>>
        where SerialA : CSerial<A>
        where SerialB : CSerial<B>
        where TestableT : CTestable<T, R>
    {
        string Name(Func<A, B, T> test) => test.Method?.Name ?? "(unnamed func)";

        TestResult<F2Trace<A, B, R>> Test(Func<A, B, T> f, int depth)
        {
            var result = new TestResult<F2Trace<A, B, R>> { };
            foreach (var a in SerialA.Series(depth))
            {
                foreach (var b in SerialB.Series(depth))
                {
                    result.Merge(TestableT.Test(f(a, b), depth), (w) => new F2Trace<A, B, R> { input1 = a, input2 = b, next = w });
                    if (result.Failed)
                    {
                        break;
                    }
                }
            }
            return result;
        }
    }