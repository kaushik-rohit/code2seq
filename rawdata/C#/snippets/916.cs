public void ToSourceCode
        (
            [NotNull] TextWriter writer
        )
        {
            int count = 0;

            writer.WriteLine("new char[] {");
            foreach (char c in Characters)
            {
                if (count == 0)
                {
                    writer.Write("   ");
                }

                writer.Write(" ");
                _CharToSourceCode(writer, c);
                writer.Write(",");

                count++;
                if (count > 10)
                {
                    count = 0;
                    writer.WriteLine();
                }
            }
            writer.WriteLine();
            writer.WriteLine("};");
        }