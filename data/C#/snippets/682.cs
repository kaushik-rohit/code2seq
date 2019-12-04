internal static bool TryParseNumericString(object candidate, out double result)
		{
			if (candidate != null)
			{
				// If a number is stored in a string, Excel will not convert it to the invariant format, so assume that it is in the current culture's number format.
				// This may not always be true, but it is a better assumption than assuming it is always in the invariant culture, which will probably never be true
				// for locales outside the United States.
				var style = NumberStyles.Float | NumberStyles.AllowThousands;
				return double.TryParse(candidate.ToString(), style, CultureInfo.CurrentCulture, out result);
			}
			result = 0;
			return false;
		}