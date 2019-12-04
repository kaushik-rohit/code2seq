protected override dynamic GetDefaultValue(dynamic column)
        {
            string defaultValue = column.COLUMN_DEFAULT;
            if (string.IsNullOrEmpty(defaultValue))
            {
                return null;
            }

            dynamic result = null;
            switch (defaultValue.ToUpper())
            {
                case "CURRENT_TIMESTAMP":
                    result = DateTime.Now;
                    break;
            }
            return result;
        }