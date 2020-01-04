private static string GetErrorDescription(Error errorCode)
		{
			switch (errorCode) 
			{
				case Error.CouldNotConnect:
					return "A connection could not be established.";
				case Error.InvalidRequest:
					return "Invalid Request. One of more of the provided fields were not correctly formatted."
						+ " The data property of the response body will contain specific error messages for"
						+ " each field.";
				case Error.TrialExpired:
					return "Trial Expired. Trial Period Expired";
				case Error.TemporaryServiceError:
					return "Temporary Service Error. A temporary error is preventing the request from being"
						+ " processed.";
				case Error.InvalidGameToken:
					return "Invalid Game Token. The provided Game-Token was not recognised.";
				case Error.InvalidCredentials:
					return "Invalid Credentials. The supplied credentials were not recognised.";
				case Error.LimitReached:
					return "Limit Reached. The DAU limit for today has been reached.";
				case Error.UnexpectedError:
				default:
					return "An unexpected server error occurred.";
			}
		}