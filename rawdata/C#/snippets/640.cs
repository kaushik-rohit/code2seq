public static async Task UnloadProject (string projectFile)
		{
			List<RemoteBuildEngine> projectBuilders;
			using (await buildersLock.EnterAsync ().ConfigureAwait (false)) {
				if (shutDown) return;
				projectBuilders = builders.GetAllBuilders ().Where (b => b.IsProjectLoaded (projectFile)).ToList ();
			}
			foreach (var b in projectBuilders)
				(await b.GetRemoteProjectBuilder (projectFile, false)).Shutdown ();
		}