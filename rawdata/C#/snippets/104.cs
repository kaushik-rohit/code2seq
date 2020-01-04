private static void GetFileIndex(
			int body, int action, int direction, int fileType, out FileIndex fileIndex, out int index)
		{
			switch (fileType)
			{
				default:
				case 1:
					fileIndex = m_FileIndex;
					if (body < 200)
					{
						index = body * 110;
					}
					else if (body < 400)
					{
						index = 22000 + ((body - 200) * 65);
					}
					else
					{
						index = 35000 + ((body - 400) * 175);
					}

					break;
				case 2:
					fileIndex = m_FileIndex2;
					if (body < 200)
					{
						index = body * 110;
					}
					else
					{
						index = 22000 + ((body - 200) * 65);
					}

					break;
				case 3:
					fileIndex = m_FileIndex3;
					if (body < 300)
					{
						index = body * 65;
					}
					else if (body < 400)
					{
						index = 33000 + ((body - 300) * 110);
					}
					else
					{
						index = 35000 + ((body - 400) * 175);
					}

					break;
				case 4:
					fileIndex = m_FileIndex4;
					if (body < 200)
					{
						index = body * 110;
					}
					else if (body < 400)
					{
						index = 22000 + ((body - 200) * 65);
					}
					else
					{
						index = 35000 + ((body - 400) * 175);
					}

					break;
				case 5:
					fileIndex = m_FileIndex5;
					if ((body < 200) && (body != 34)) // looks strange, though it works.
					{
						index = body * 110;
					}
					else if (body < 400)
					{
						index = 22000 + ((body - 200) * 65);
					}
					else
					{
						index = 35000 + ((body - 400) * 175);
					}

					break;
			}

			index += action * 5;

			if (direction <= 4)
			{
				index += direction;
			}
			else
			{
				index += direction - (direction - 4) * 2;
			}
		}