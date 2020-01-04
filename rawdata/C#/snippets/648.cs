static string GetExeLocationInBundle (string toolsVersion)
		{
			var mdBinDir = new FilePath (typeof (MSBuildProjectService).Assembly.Location).ParentDirectory;
			var exe = mdBinDir.Combine ("MonoDevelop.MSBuildBuilder.exe");
			if (File.Exists (exe))
				return exe;

			throw new InvalidOperationException ($"Did not find MSBuild builder '{exe}'");
		}