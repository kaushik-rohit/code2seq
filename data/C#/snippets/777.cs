public Task<bool> HandleAsync(IHttpContext context)
		{
			if (InternalRedirect)
			{
				context.Response.InternalRedirect(RedirectTarget);
			}
			else
			{
				context.Response.StatusCode = StatusCode;
				context.Response.StatusMessage = StatusMessge;
				context.Response.AddHeader("Location", RedirectTarget);
			}

			return Task.FromResult(true);
		}