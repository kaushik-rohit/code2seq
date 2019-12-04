[PublicAPI]
        [Pure]
        [NotNull]
        public static String ToShortDateString( this DateTime dateTime, [NotNull] CultureInfo culture )
        {
            culture.ThrowIfNull( nameof(culture) );

            return dateTime.ToString( "d", culture );
        }