public void WriteLocalFile
            (
                [NotNull] string fileName
            )
        {
            using (StreamWriter writer = new StreamWriter
                (
                    File.Create(fileName),
                    IrbisEncoding.Ansi
                ))
            {
                WriteTable(writer);
            }
        }