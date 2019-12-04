public static async Task RecycleAllBuilders ()
		{
			using (await buildersLock.EnterAsync ().ConfigureAwait (false)) {
				if (shutDown) return;
				foreach (var b in builders.GetAllBuilders ().ToList ())
					ShutdownBuilderNoLock (b);
			}
		}