private static string ConvertDukascopySymbolToLeanSymbol(string dukascopySymbol)
        {
            string leanSymbol;
            return MapDukascopyToLean.TryGetValue(dukascopySymbol, out leanSymbol) ? leanSymbol : string.Empty;
        }