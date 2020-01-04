public static uint[,] ExtractRedChannel(ImageData img)
		{
			uint[,] red = new uint[img.Width, img.Height];
			for(int column = 0; column < img.Width; column++)
			{
				for(int row = 0; row < img.Height; row++)
				{
					Color c = img.GetPixel(column, row);
					red[column, row] = c.R;
				}
			}

			return red;
		}