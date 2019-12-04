private static string ConvertLeanSymbolToDukascopySymbol(string leanSymbol)
        {
            string dukascopySymbol;
            return MapLeanToDukascopy.TryGetValue(leanSymbol, out dukascopySymbol) ? dukascopySymbol : string.Empty;
        }