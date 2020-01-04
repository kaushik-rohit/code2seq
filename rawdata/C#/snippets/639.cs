async static Task<RemoteBuildEngine> GetBuildEngine (TargetRuntime runtime, string minToolsVersion, string solutionFile, string group, object buildSessionId, bool setBusy = false, bool allowBusy = true)
		{
			var binDir = MSBuildProjectService.GetMSBuildBinPath (runtime);

			Version tv = Version.Parse (MSBuildProjectService.ToolsVersion);
			if (Version.TryParse (minToolsVersion, out Version mtv) && tv < mtv) {
				throw new InvalidOperationException (string.Format (
					"Project requires MSBuild ToolsVersion '{0}' which is not supported by runtime '{1}'",
					minToolsVersion, runtime.Id)
				);
			}

			// One builder per solution
			string builderKey = runtime.Id + " # " + solutionFile + " # " + group;

			RemoteBuildEngine builder = null;

			// Find builders which are not being shut down

			var candiateBuilders = builders.GetBuilders (builderKey).Where (b => !b.IsShuttingDown && (!b.IsBusy || allowBusy));

			if (buildSessionId != null) {

				// Look for a builder that already started the session.
				// If there isn't one, pick builders which don't have any session assigned, so a new one
				// can be started.

				var sessionBuilders = candiateBuilders.Where (b => b.BuildSessionId == buildSessionId);
				if (!sessionBuilders.Any ())
					sessionBuilders = candiateBuilders.Where (b => b.BuildSessionId == null);
				candiateBuilders = sessionBuilders;
			} else
				// Pick builders which are not bound to any session
				candiateBuilders = candiateBuilders.Where (b => b.BuildSessionId == null);

			// Prefer non-busy builders

			builder = candiateBuilders.FirstOrDefault (b => !b.IsBusy) ?? candiateBuilders.FirstOrDefault ();

			if (builder != null) {
				if (setBusy)
					builder.SetBusy ();
				if (builder.BuildSessionId == null && buildSessionId != null) {
					// If a new session is being assigned, signal the session start
					builder.BuildSessionId = buildSessionId;
					var si = (SessionInfo)buildSessionId;
					await builder.BeginBuildOperation (si.Monitor, si.Logger, si.Verbosity, si.Configurations).ConfigureAwait (false);
				}
				builder.CancelScheduledDisposal ();
				return builder;
			}

			// No builder available with the required constraints. Start a new builder

			return await Task.Run (async () => {

				// Always start the remote process explicitly, even if it's using the current runtime and fx
				// else it won't pick up the assembly redirects from the builder exe

				var exe = GetExeLocation (runtime);
				RemoteProcessConnection connection = null;

				try {

					connection = new RemoteProcessConnection (exe, runtime.GetExecutionHandler ());
					await connection.Connect ().ConfigureAwait (false);

					var props = GetCoreGlobalProperties (solutionFile, binDir, MSBuildProjectService.ToolsVersion);
					foreach (var gpp in MSBuildProjectService.GlobalPropertyProviders) {
						foreach (var e in gpp.GetGlobalProperties ())
							props [e.Key] = e.Value;
					}

					await connection.SendMessage (new InitializeRequest {
						IdeProcessId = Process.GetCurrentProcess ().Id,
						BinDir = binDir,
						CultureName = GettextCatalog.UICulture.Name,
						GlobalProperties = props
					}).ConfigureAwait (false);

					builder = new RemoteBuildEngine (connection, solutionFile);

				} catch {
					if (connection != null) {
						try {
							connection.Dispose ();
						} catch {
						}
					}
					throw;
				}

				builders.Add (builderKey, builder);
				builder.ReferenceCount = 0;
				builder.BuildSessionId = buildSessionId;
				builder.Disconnected += async delegate {
					using (await buildersLock.EnterAsync ().ConfigureAwait (false))
						builders.Remove (builder);
				};
				if (setBusy)
					builder.SetBusy ();
				if (buildSessionId != null) {
					var si = (SessionInfo)buildSessionId;
					await builder.BeginBuildOperation (si.Monitor, si.Logger, si.Verbosity, si.Configurations);
				}
				return builder;
			});
		}