public static bool Contains(int body)
		{
			if (Table1 != null && body >= 0 && body < Table1.Length && Table1[body] != -1)
			{
				return true;
			}

			if (Table2 != null && body >= 0 && body < Table2.Length && Table2[body] != -1)
			{
				return true;
			}

			if (Table3 != null && body >= 0 && body < Table3.Length && Table3[body] != -1)
			{
				return true;
			}

			if (Table4 != null && body >= 0 && body < Table4.Length && Table4[body] != -1)
			{
				return true;
			}

			return false;
		}