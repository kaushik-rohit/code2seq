public static FilterType GetFilterType(FilterBase filter)
    {
      string s = filter.GetType().Name.ToUpper();
      if (s == "LPFILTER")
        return FilterType.LP;
      if (s == "HPFILTER")
        return FilterType.HP;
      if (s == "DUEFILTER")
        return FilterType.DUE;
      if (s == "SEFILTER")
        return FilterType.SE;
      if (s == "NOTCHFILTER")
        return FilterType.NOTCH;
      if (s == "GFILTER")
        return FilterType.G;
      if (s == "INVGFILTER")
        return FilterType.InvG;
      if (s == "BPFILTER")
        return FilterType.BP;
      if (s == "RECTIFIER")
        return FilterType.RECT;
      if (s == "SINGLESIDERECTIFIER")
        return FilterType.SingleSideRect;
      if (s == "BP12FILTER")
        return FilterType.BP12;
      if (s == "DCATTFILTER")
        return FilterType.DCatt;
      if (s == "INVDCATTFILTER")
        return FilterType.InvDCatt;
      if (s == "DUE1987FILTER")
        return FilterType.DUE1987;
      if (s == "DUE2007FILTER")
        return FilterType.DUE2007;
      if (s == "LP05FILTER")
        return FilterType.LP05;
      if (s == "LP05NSFILTER")
        return FilterType.LP05NS;
      if (s == "HP05NSFILTER")
        return FilterType.HP05NS;
      if (s == "MEDIANFILTER")
        return FilterType.Median;
      if (s == "SQRFILTER")
        return FilterType.Square;
      if (s == "SQRTFILTER")
        return FilterType.Squareroot;
      if (s == "MEANFILTERQUICK")
        return FilterType.Mean;
      if (s == "PERCENTILLIANFILTER")
        return FilterType.Percentillian;
      if (s == "DBFILTER")
        return FilterType.dB;
      if (s == "GAINDIVONEMINUSX")
        return FilterType.GainDivOneMinusX;
      if (s == "DESPECKLER")
        return FilterType.Despeckler;
      throw new ArgumentException("Unknown filter object");
    }