public static int GetAnimLength(int body, int fileType)
		{
			int length = 0;
			switch (fileType)
			{
				default:
				case 1:
					if (body < 200)
					{
						length = 22; //high
					}
					else if (body < 400)
					{
						length = 13; //low
					}
					else
					{
						length = 35; //people
					}
					break;
				case 2:
					if (body < 200)
					{
						length = 22; //high
					}
					else
					{
						length = 13; //low
					}
					break;
				case 3:
					if (body < 300)
					{
						length = 13;
					}
					else if (body < 400)
					{
						length = 22;
					}
					else
					{
						length = 35;
					}
					break;
				case 4:
					if (body < 200)
					{
						length = 22;
					}
					else if (body < 400)
					{
						length = 13;
					}
					else
					{
						length = 35;
					}
					break;
				case 5:
					if (body < 200)
					{
						length = 22;
					}
					else if (body < 400)
					{
						length = 13;
					}
					else
					{
						length = 35;
					}
					break;
			}
			return length;
		}