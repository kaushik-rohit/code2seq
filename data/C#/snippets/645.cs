internal static object StartBuildSession (ProgressMonitor monitor, MSBuildLogger logger, MSBuildVerbosity verbosity, ProjectConfigurationInfo[] configurations)
		{
			CheckShutDown ();
			return new SessionInfo {
					Monitor = monitor,
					Verbosity = verbosity,
					Logger = logger,
					Configurations = configurations
				};
		}