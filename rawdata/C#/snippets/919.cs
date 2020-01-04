public void WriteTable
            (
                [NotNull] TextWriter writer
            )
        {
            int count = 0;

            foreach (byte b in _table)
            {
                if (count != 0)
                {
                    writer.Write(" ");
                }
                writer.Write
                    (
                        "{0:000}",
                        b
                    );
                count++;
                if (count == 32)
                {
                    writer.WriteLine();
                    count = 0;
                }
            }
        }