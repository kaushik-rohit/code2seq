public IDisposable CreateLogScope(IList<KeyValuePair<string, string>> properties)
		{
			return Serilog.Context.LogContext.Push
			(
				properties.Select
				(
					p => new PropertyEnricher(p.Key, p.Value)
				).Cast<ILogEventEnricher>()
				.ToArray()
			);
		}