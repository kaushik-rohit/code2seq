public static void Translate(ref int body, ref int hue)
		{
			if (m_Table == null)
			{
				LoadTable();
			}
			if (body <= 0 || body >= m_Table.Length)
			{
				body = 0;
				return;
			}

			int table = m_Table[body];

			if ((table & (1 << 31)) != 0)
			{
				body = table & 0x7FFF;

				int vhue = (hue & 0x3FFF) - 1;

				if (vhue < 0 || vhue >= Hues.List.Length)
				{
					hue = (table >> 15) & 0xFFFF;
				}
			}
		}