public SecurityType GetBrokerageSecurityType(string brokerageSymbol)
        {
            return (brokerageSymbol.Length == 6 && KnownCurrencies.Contains(brokerageSymbol.Substring(0, 3)) && KnownCurrencies.Contains(brokerageSymbol.Substring(3, 3)))
                ? SecurityType.Forex
                : SecurityType.Cfd;
        }