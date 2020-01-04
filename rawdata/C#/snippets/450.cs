public static void Init(AppHostBase appHost)
		{
			appHost.RequestFilters.Add((req, res, dto) => {

				string sessionId = req.GetPermanentSessionId();
				using (var client = appHost.GetCacheClient())
				{
					IAuthSession session = client.GetSession(sessionId);

					ApplyTo httpMethod = req.HttpMethodAsApplyTo();

					var attributes = (RequiredPermissionAttribute[])dto.GetType().GetCustomAttributes(typeof(RequiredPermissionAttribute), true);
					foreach (var attribute in attributes)
					{
						if (attribute.ApplyTo.Has(httpMethod))
						{
							foreach (string requiredPermission in attribute.RequiredPermissions)
							{
								if (!session.HasPermission(requiredPermission))
								{
									res.StatusCode = (int)HttpStatusCode.Unauthorized;
									res.StatusDescription = "Invalid Permissions";
									res.Close();
									return;
								}
							}
						}
					}
				}

			});
		}