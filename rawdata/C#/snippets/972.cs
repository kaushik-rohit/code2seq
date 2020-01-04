[Pure]
        [PublicAPI]
        public static Int64 ToInt64( [NotNull] this String value )
        {
            value.ThrowIfNull( nameof(value) );

            return Int64.Parse( value );
        }