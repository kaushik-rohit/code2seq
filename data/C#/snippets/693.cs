public static T GetTypedCellValue<T>(object value)
        {
            if (value == null)
                return default(T);

            var fromType = value.GetType();
            var toType = typeof(T);
            var toNullableUnderlyingType = (TypeCompat.IsGenericType(toType) && toType.GetGenericTypeDefinition() == typeof(Nullable<>))
                ? Nullable.GetUnderlyingType(toType)
                : null;

            if (fromType == toType || fromType == toNullableUnderlyingType)
                return (T)value;

            // if converting to nullable struct and input is blank string, return null
            if (toNullableUnderlyingType != null && fromType == typeof(string) && ((string)value).Trim() == string.Empty)
                return default(T);

            toType = toNullableUnderlyingType ?? toType;

            if (toType == typeof(DateTime))
            {
                if (value is double)
                    return (T)(object)(DateTime.FromOADate((double)value));

                if (fromType == typeof(TimeSpan))
                    return ((T)(object)(new DateTime(((TimeSpan)value).Ticks)));

                if (fromType == typeof(string))
                    return (T)(object)DateTime.Parse(value.ToString());
            }
            else if (toType == typeof(TimeSpan))
            {
                if (value is double)
                    return (T)(object)(new TimeSpan(DateTime.FromOADate((double)value).Ticks));

                if (fromType == typeof(DateTime))
                    return ((T)(object)(new TimeSpan(((DateTime)value).Ticks)));

                if (fromType == typeof(string))
                    return (T)(object)TimeSpan.Parse(value.ToString());
            }

            return (T)Convert.ChangeType(value, toType);
        }