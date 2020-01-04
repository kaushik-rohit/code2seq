public PayNotifyBuilder WithPayNotifyFunc(Func<PayNotifyInput, Task<string>> payNotifyFunc)
        {
            PayNotifyFunc = payNotifyFunc;
            return this;
        }