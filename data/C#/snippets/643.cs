public static async Task RefreshProjectWithContent (string projectFile, string projectContent)
		{
			List<RemoteBuildEngine> projectBuilders;
			using (await buildersLock.EnterAsync ().ConfigureAwait (false)) {
				if (shutDown) return;
				projectBuilders = builders.GetAllBuilders ().Where (b => b.IsProjectLoaded (projectFile)).ToList ();
			}
			foreach (var b in projectBuilders)
				await (await b.GetRemoteProjectBuilder (projectFile, false)).RefreshWithContent (projectContent);
		}