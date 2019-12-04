public static FilterBase GetFilterByName(string filterName)
    {
      filterName = filterName.Trim().ToUpper();
      int filterNameIndex = FilterNames.ToList().IndexOf(filterName);
      if (filterNameIndex < 0)
        return null;
      FilterType filterType = (FilterType)Enum.ToObject(typeof(FilterType), filterNameIndex);
      switch (filterType)
      {
        //case FilterType.LP:
        //  return new LPFilter();
        //case FilterType.HP:
        //  return new HPFilter();
        //case FilterType.NOTCH:
        //  return new NotchFilter();
        //case FilterType.RECT:
        //  return new Rectifier();
        //case FilterType.SingleSideRect:
        //  return new SingleSideRectifier();
        //case FilterType.BP:
        //  return new BPFilter();
        case FilterType.DUE:
          return new DUEFilter();
        case FilterType.SE:
          return new SEFilter();
        //case FilterType.G:
        //  return new GFilter();
        //case FilterType.InvG:
        //  return new InvGFilter();
        //case FilterType.BP12:
        //  return new BP12Filter();
        //case FilterType.DCatt:
        //  return new DCattFilter();
        //case FilterType.InvDCatt:
        //  return new INVDCattFilter();
        //case FilterType.DUE1987:
        //  return new DUE1987Filter();
        //case FilterType.DUE2007:
        //  return new DUE2007Filter();
        //case FilterType.LP05:
        //  return new LP05Filter();
        //case FilterType.LP05NS:
        //  return new LP05NSFilter();
        //case FilterType.HP05NS:
        //  return new HP05NSFilter();
        //case FilterType.Median:
        //  return new MedianFilter();
        //case FilterType.Square:
        //  return new SqrFilter();
        //case FilterType.Squareroot:
        //  return new SqrtFilter();
        //case FilterType.Mean:
        //  return new MeanFilterQuick();
        //case FilterType.Percentillian:
        //  return new PercentillianFilter();
        //case FilterType.dB:
        //  return new DBFilter();
        //case FilterType.GainDivOneMinusX:
        //  return new GainDivOneMinusX();
        //case FilterType.Despeckler:
        //  return new Despeckler();
        default:
          throw new ArgumentOutOfRangeException();
      }
    }