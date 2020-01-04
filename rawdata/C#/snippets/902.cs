public virtual void RegisterFactories()
		{
			Bind<IBlobStorageStoreConnectionStringFactory>()
				.To<BlobStorageEventStoreConnectionStringFactory>()
				.InSingletonScope();
			Bind<IBlobStorageSnapshotStoreConnectionStringFactory>()
				.To<BlobStorageSnapshotStoreConnectionStringFactory>()
				.InSingletonScope();
		}