public static FilterBase Parse(string value)
    {
      FilterBase result = null;
      string s = value;
      if (s.Contains("(") && s.EndsWith(")"))
      {
        result = GetFilterByName(TextUtils.StripStringValue(ref s, "("));
        if (result != null)
        {
          s = s.Remove(s.Length - 1, 1);
          int i = 2;
          while (s != string.Empty)
          {
            double parsedValue;
            string t = TextUtils.StripStringValue(ref s, "/");
            if (double.TryParse(t, NumberStyles.Float, CultureInfo.InvariantCulture, out parsedValue))
            {
              if (!result.Setting[i].IsReadOnly)
                result.Setting[i].Value = parsedValue;
            }
            else
              result.StringSetting[i] = t;
            i++;
          }
        }
      }
      else
        if (!s.Contains("(") && !s.Contains(")"))
          result = GetFilterByName(s.Trim());
      return result;
    }