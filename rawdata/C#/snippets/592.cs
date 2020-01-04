public string ToString(Conjunction conjunction)
        {
            switch (conjunction)
            {
                case Conjunction.And:
                    return "AND";
                case Conjunction.Or:
                    return "OR";
                default:
                    throw new ArgumentException(Resources.UnknownConjunction, "conjunction");
            }
        }