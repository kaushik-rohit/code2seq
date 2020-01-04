void RegisterDependencies()
    {
      var builder = new ContainerBuilder();

      builder.RegisterInstance( new EnvironmentService() ).As<IEnvironmentService>();

      builder.RegisterInstance( new HttpClientHandlerFactory() ).As<IHttpClientHandlerFactory>();

      builder.RegisterInstance( new DatastoreFolderPathProvider() ).As<IDatastoreFolderPathProvider>();

      // Set the data source dependent on whether or not the data parition phrase is "UseLocalDataSource".
      // The local data source is mainly for use in TestCloud test runs, but the app can be used in local-only data mode if desired.
      if( Settings.IsUsingLocalDataSource )
        builder.RegisterInstance( _LazyFilesystemOnlyAcquaintanceDataSource.Value ).As<IDataSource<Acquaintance>>();
      else
        builder.RegisterInstance( _LazyBackendlessAcquaintanceSource.Value ).As<IDataSource<Acquaintance>>();

      _IoCContainer = builder.Build();

      var csl = new AutofacServiceLocator( _IoCContainer );
      ServiceLocator.SetLocatorProvider( () => csl );
    }