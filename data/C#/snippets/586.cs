public static string GetFilterName(FilterType filterType)
    {
      int i = Convert.ToInt32(filterType);
      return FilterNames[i];
    }