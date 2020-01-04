public static int GetAnimCount(int fileType)
		{
			int count;
			switch (fileType)
			{
				default:
				case 1:
					count = 400 + (int)(m_FileIndex.IdxLength - 35000 * 12) / (12 * 175);
					break;
				case 2:
					count = 200 + (int)(m_FileIndex2.IdxLength - 22000 * 12) / (12 * 65);
					break;
				case 3:
					count = 400 + (int)(m_FileIndex3.IdxLength - 35000 * 12) / (12 * 175);
					break;
				case 4:
					count = 400 + (int)(m_FileIndex4.IdxLength - 35000 * 12) / (12 * 175);
					break;
				case 5:
					count = 400 + (int)(m_FileIndex5.IdxLength - 35000 * 12) / (12 * 175);
					break;
			}
			return count;
		}