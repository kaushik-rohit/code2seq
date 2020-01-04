public virtual void ToColAndRow(string address, out int col, out int row, RangeCalculationBehaviour behaviour)
        {
            address = Utils.ConvertUtil._invariantTextInfo.ToUpper(address);
            var alphaPart = GetAlphaPart(address);
            col = 0;
            var nLettersInAlphabet = 26;
            for (int x = 0; x < alphaPart.Length; x++)
            {
                var pos = alphaPart.Length - x - 1;
                var currentNumericValue = GetNumericAlphaValue(alphaPart[x]);
                col += (nLettersInAlphabet * pos * currentNumericValue);
                if (pos == 0)
                {
                    col += currentNumericValue;
                }
            }
            //col--;
            //row = GetIntPart(address) - 1 ?? GetRowIndexByBehaviour(behaviour);
            row = GetIntPart(address) ?? GetRowIndexByBehaviour(behaviour);

        }