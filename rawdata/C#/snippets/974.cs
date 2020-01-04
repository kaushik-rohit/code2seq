[Pure]
        [PublicAPI]
        public static Int64 ToInt64( [NotNull] this String value, [NotNull] IFormatProvider formatProvider )
        {
            value.ThrowIfNull( nameof(value) );
            formatProvider.ThrowIfNull( nameof(formatProvider) );

            return Int64.Parse( value, formatProvider );
        }