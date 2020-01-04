internal static bool TryParseDateString(object candidate, out DateTime result)
		{
			if (candidate != null)
			{
				var style = DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal;
				// If a date is stored in a string, Excel will not convert it to the invariant format, so assume that it is in the current culture's date/time format.
				// This may not always be true, but it is a better assumption than assuming it is always in the invariant culture, which will probably never be true
				// for locales outside the United States.
				return DateTime.TryParse(candidate.ToString(), CultureInfo.CurrentCulture, style, out result);
			}
			result = DateTime.MinValue;
			return false;
		}