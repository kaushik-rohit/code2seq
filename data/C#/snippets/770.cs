public static string ToEmmeFloat(float number)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append((int)number);
            number = (float)Math.Round(number, 6);
            number = number - (int)number;
            if (number > 0)
            {
                var integerSize = builder.Length;
                builder.Append('.');
                for (int i = integerSize; i < 4; i++)
                {
                    number = number * 10;
                    builder.Append((int)number);
                    number = number - (int)number;
                    // ReSharper disable once CompareOfFloatsByEqualityOperator
                    if (number == 0)
                    {
                        break;
                    }
                }
            }
            return builder.ToString();
        }