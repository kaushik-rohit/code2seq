public SecurityType GetLeanSecurityType(string leanSymbol)
        {
            string dukascopySymbol;
            if (!MapLeanToDukascopy.TryGetValue(leanSymbol, out dukascopySymbol))
                throw new ArgumentException("Unknown Lean symbol: " + leanSymbol);

            return GetBrokerageSecurityType(dukascopySymbol);
        }