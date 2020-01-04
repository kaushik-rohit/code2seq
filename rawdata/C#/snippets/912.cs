[NotNull]
        public static IrbisAlphabetTable ParseText
            (
                [NotNull] TextReader reader
            )
        {
            byte[] table = _ParseText(reader);

            IrbisAlphabetTable result = new IrbisAlphabetTable
                (
                    IrbisEncoding.Ansi,
                    table
                );

            return result;
        }