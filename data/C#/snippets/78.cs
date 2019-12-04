public static void Translate(ref int body)
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

			body = m_Table[body] & 0x7FFF;
		}