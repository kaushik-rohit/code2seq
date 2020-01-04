void UpdateDataSourceIfNecessary()
    {
      var dataSource = ServiceLocator.Current.GetInstance<IDataSource<Acquaintance>>();

      // Set the data source dependent on whether or not the data parition phrase is "UseLocalDataSource".
      // The local data source is mainly for use in TestCloud test runs, but the app can be used in local-only data mode if desired.

      // if the settings dictate that a local data source should be used, then register the local data provider and update the IoC container
      if( Settings.IsUsingLocalDataSource && !(dataSource is FilesystemOnlyAcquaintanceDataSource) )
      {
        var builder = new ContainerBuilder();
        builder.RegisterInstance( _LazyFilesystemOnlyAcquaintanceDataSource.Value ).As<IDataSource<Acquaintance>>();
        builder.Update( _IoCContainer );
        return;
      }

      // if the settings dictate that a local data souce should not be used, then register the remote data source and update the IoC container
      if( !Settings.IsUsingLocalDataSource && !(dataSource is BackendlessDataSource) )
      {
        var builder = new ContainerBuilder();
        builder.RegisterInstance( _LazyBackendlessAcquaintanceSource.Value ).As<IDataSource<Acquaintance>>();
        builder.Update( _IoCContainer );
      }
    }