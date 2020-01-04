public static bool[,] FindColors(ImageData img, Color searchColor, uint tolerance)
		{
			bool[,] grid = new bool[img.Width, img.Height];
			for(int column = 0; column < img.Width; column++)
			{
				for(int row = 0; row < img.Height; row++)
				{
					if(ColorsSimilar(img.GetPixel(column, row), searchColor, tolerance))
					{
						grid[column, row] = true;
					}
					else
					{
						grid[column, row] = false;
					}
				}
			}

			return grid;
		}