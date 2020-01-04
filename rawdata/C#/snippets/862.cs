[PublicAPI]
        [NotNull]
        public static IDictionary<TValue, TKey> ConcatAllToDictionarySafe<TValue, TKey>(
            [NotNull] this IDictionary<TValue, TKey> dictionary,
            [NotNull] [ItemCanBeNull] params IDictionary<TValue, TKey>[] dictionaries )
        {
            dictionary.ThrowIfNull( nameof(dictionary) );
            dictionaries.ThrowIfNull( nameof(dictionaries) );

            var result = dictionary;
            dictionaries.ForEach( x =>
            {
                if ( x == null )
                    return;

                x.ForEach( y =>
                {
                    if ( !result.ContainsKey( y.Key ) )
                        result.Add( y.Key, y.Value );
                } );
            } );

            return result;
        }