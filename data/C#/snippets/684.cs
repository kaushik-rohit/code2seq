internal static bool TryParseBooleanString(object candidate, out bool result)
		{
			if (candidate != null)
				return bool.TryParse(candidate.ToString(), out result);
			result = false;
			return false;
		}