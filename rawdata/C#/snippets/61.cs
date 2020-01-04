public static HashSet<T> ToHashSet<T>( this IEnumerable<T> collection )
        {
            collection.ThrowIfNull( nameof(collection) );

            return new HashSet<T>( collection );
        }