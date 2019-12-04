internal void UpdateIfBest()
            {
                var currentValue = Job.Value;
                // if this value is better than anything we have seen before
                if (Maximize ? currentValue > BestValue : currentValue < BestValue)
                {
                    var bestParameters = BestParameters;
                    var currentParameters = Job.Parameters;
                    BestValue = currentValue;
                    for (int i = 0; i < bestParameters.Length; i++)
                    {
                        bestParameters[i] = currentParameters[i].Current;
                    }
                }
            }