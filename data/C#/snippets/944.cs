public static bool IsValidTablePrefix(string tablePrefix)
        {
            if (tablePrefix.Length > 0 && tablePrefix.Length < 3)
            {
                tablePrefix = tablePrefix + "abc";
            };

            return IsValidTableName(tablePrefix);
        }