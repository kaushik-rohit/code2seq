public static async Task UnloadSolution (string solutionFile)
		{
			using (await buildersLock.EnterAsync ().ConfigureAwait (false)) {
				if (shutDown) return;
				foreach (var engine in builders.GetAllBuilders ().Where (b => b.SolutionFile == solutionFile).ToList ())
					ShutdownBuilderNoLock (engine);
			}
		}