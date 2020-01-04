public static int Convert(ref int body)
		{
			if (Table1 != null && body >= 0 && body < Table1.Length)
			{
				int val = Table1[body];

				if (val != -1)
				{
					body = val;
					return 2;
				}
			}

			if (Table2 != null && body >= 0 && body < Table2.Length)
			{
				int val = Table2[body];

				if (val != -1)
				{
					body = val;
					return 3;
				}
			}

			if (Table3 != null && body >= 0 && body < Table3.Length)
			{
				int val = Table3[body];

				if (val != -1)
				{
					body = val;
					return 4;
				}
			}

			if (Table4 != null && body >= 0 && body < Table4.Length)
			{
				int val = Table4[body];

				if (val != -1)
				{
					body = val;
					return 5;
				}
			}

			return 1;
		}