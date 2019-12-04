[Csla.RunLocal]
        protected override void DataPortal_Create()
        {
            LoadProperty(Continent_IDProperty, System.Threading.Interlocked.Decrement(ref _lastID));
            LoadProperty(E03_Continent_SingleObjectProperty, DataPortal.CreateChild<E03_Continent_Child>());
            LoadProperty(E03_Continent_ASingleObjectProperty, DataPortal.CreateChild<E03_Continent_ReChild>());
            LoadProperty(E03_SubContinentObjectsProperty, DataPortal.CreateChild<E03_SubContinentColl>());
            var args = new DataPortalHookArgs();
            OnCreate(args);
            base.DataPortal_Create();
        }