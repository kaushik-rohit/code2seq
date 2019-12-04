public static bool IsValidTableName(string tableName)
        {
            Regex regex = new Regex(@"^[A-Za-z][A-Za-z0-9]{2,62}$");
            return regex.IsMatch(tableName);
        }