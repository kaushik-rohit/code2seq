static string GetExeLocation (TargetRuntime runtime)
		{
			// Return a local copy of the builder executable.
			// That local copy is configured to add additional msbuild search paths defined by add-ins.
			return GetLocalMSBuildExeLocation (runtime);
		}