public static void ToEmmeFloat(float number, StringBuilder builder)
        {
            builder.Clear();
            builder.Append((int)number);
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
        }