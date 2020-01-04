[NotNull]
        public static IrbisAlphabetTable ParseLocalFile
            (
                [NotNull] string fileName
            )
        {
            using (StreamReader reader
                = new StreamReader
                    (
                        File.OpenRead(fileName),
                        IrbisEncoding.Ansi
                    ))
            {
                return ParseText(reader);
            }
        }