public async static Task<IRemoteProjectBuilder> GetRemoteProjectBuilder (string projectFile, string solutionFile, TargetRuntime runtime, string minToolsVersion, object buildSessionId, bool setBusy = false, bool allowBusy = true)
		{
			CheckShutDown ();

			RemoteBuildEngine engine;
			using (await buildersLock.EnterAsync ().ConfigureAwait (false)) {
				// Get a builder with the provided requirements
				engine = await GetBuildEngine (runtime, minToolsVersion, solutionFile, "", buildSessionId, setBusy, allowBusy);

				// Add a reference to make sure the engine is alive while the builder is being used.
				// This reference will be freed when ReleaseReference() is invoked on the builder.
				engine.ReferenceCount++;
				try {
					return new RemoteProjectBuilderProxy (await engine.GetRemoteProjectBuilder (projectFile, true), setBusy);
				} catch {
					// Something went wrong, release the above engine reference, since it won't be possible to free it through the builder
					ReleaseProjectBuilderNoLock (engine).Ignore ();
					throw;
				}
			}
		}