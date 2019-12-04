public static double[] AverageRgbValues(ImageData img, int left = 0, int top = 0, int width = -1, int height = -1)
		{
			long[] totals = { 0, 0, 0 };

			if(width == -1)
			{
				width = img.Width;
			}
			if(height == -1)
			{
				height = img.Height;
			}

			for(int x = left; x < left + width; x++)
			{
				for(int y = top; y < top + height; y++)
				{
					Color currentColor = img.GetPixel(x, y);
					totals[0] += currentColor.R;
					totals[1] += currentColor.G;
					totals[2] += currentColor.B;
				}
			}

			int count = width * height;
			double[] retvar = { totals[0] / (double)count, totals[1] / (double)count, totals[2] / (double)count };
			return retvar;
		}