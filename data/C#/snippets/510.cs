[PublicAPI]
        [Pure]
        [NotNull]
        public static String ToShortDateString( this DateTime dateTime, [NotNull] DateTimeFormatInfo formatInfo )
        {
            dateTime.ThrowIfNull( nameof(dateTime) );
            formatInfo.ThrowIfNull( nameof(formatInfo) );

            return dateTime.ToString( "d", formatInfo );
        }