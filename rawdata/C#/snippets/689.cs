internal static void ExcelEncodeString(StreamWriter sw, string t)
        {
            if (Regex.IsMatch(t, "(_x[0-9A-F]{4,4}_)"))
            {
                var match = Regex.Match(t, "(_x[0-9A-F]{4,4}_)");
                int indexAdd = 0;
                while (match.Success)
                {
                    t = t.Insert(match.Index + indexAdd, "_x005F");
                    indexAdd += 6;
                    match = match.NextMatch();
                }
            }
            for (int i = 0; i < t.Length; i++)
            {
                if (t[i] <= 0x1f && t[i] != '\t' && t[i] != '\n' && t[i] != '\r') //Not Tab, CR or LF
                {
                    sw.Write("_x00{0}_", (t[i] < 0xf ? "0" : "") + ((int)t[i]).ToString("X"));
                }
                else
                {
                    sw.Write(t[i]);
                }
            }

        }