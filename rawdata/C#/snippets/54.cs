public static int GetTrueBody(int FileType, int index)
		{
			switch (FileType)
			{
				default:
				case 1:
					return index;
				case 2:
					if (Table1 != null && index >= 0)
					{
						for (int i = 0; i < Table1.Length; ++i)
						{
							if (Table1[i] == index)
							{
								return i;
							}
						}
					}
					break;
				case 3:
					if (Table2 != null && index >= 0)
					{
						for (int i = 0; i < Table2.Length; ++i)
						{
							if (Table2[i] == index)
							{
								return i;
							}
						}
					}
					break;
				case 4:
					if (Table3 != null && index >= 0)
					{
						for (int i = 0; i < Table3.Length; ++i)
						{
							if (Table3[i] == index)
							{
								return i;
							}
						}
					}
					break;
				case 5:
					if (Table4 != null && index >= 0)
					{
						for (int i = 0; i < Table4.Length; ++i)
						{
							if (Table4[i] == index)
							{
								return i;
							}
						}
					}
					break;
			}
			return -1;
		}