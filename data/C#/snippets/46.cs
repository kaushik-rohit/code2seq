public IObservable<Unit> InitializeAsObservable()
        {
            if (isInitialized) return Observable.Return(Unit.Default);
            return initializeSubject ?? (initializeSubject = new Subject<Unit>());
        }