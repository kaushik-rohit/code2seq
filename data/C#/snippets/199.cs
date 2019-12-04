protected override string GetAggregateFunction(string aggregateCalled)
        {
            switch (aggregateCalled)
            {
                case "sum":
                    return "SUM";
                case "max":
                    return "MAX";
                case "min":
                    return "MIN";
                case "avg":
                    return "AVG";
                default:
                    return null;
            }
        }