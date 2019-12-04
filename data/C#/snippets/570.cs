public bool IsKnownLeanSymbol(Symbol symbol)
        {
            if (symbol == null || string.IsNullOrWhiteSpace(symbol.Value))
                return false;

            var dukascopySymbol = ConvertLeanSymbolToDukascopySymbol(symbol.Value);

            return MapDukascopyToLean.ContainsKey(dukascopySymbol) && GetBrokerageSecurityType(dukascopySymbol) == symbol.ID.SecurityType;
        }