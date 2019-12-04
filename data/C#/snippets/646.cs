internal static async Task EndBuildSession (object session)
		{
			using (await buildersLock.EnterAsync ().ConfigureAwait (false)) {
				if (shutDown) return;
				foreach (var b in builders.GetAllBuilders ())
					if (b.BuildSessionId == session) {
						b.BuildSessionId = null;

						var si = (SessionInfo)session;
						await b.EndBuildOperation (si.Monitor);
					}
			}
		}