public static double Similarity(
			ImageData img,
			ImageData reference,
			int left = 0,
			int top = 0,
			int width = -1,
			int height = -1,
			int offsetLeft = 0,
			int offsetTop = 0)
		{
			double sim = 0.0;
			width = (width == -1) ? img.Width - left : width;
			height = (height == -1) ? img.Height - top : height;

			if((img.Width == reference.Width) && (img.Height == reference.Height))
			{
				for(int column = left; column < left + width; column++)
				{
					for(int row = top; row < top + height; row++)
					{
						Color a = img.GetPixel(offsetLeft + column, offsetTop + row);
						Color b = reference.GetPixel(column, row);

						int cr = Math.Abs(a.R - b.R);
						int cg = Math.Abs(a.G - b.G);
						int cb = Math.Abs(a.B - b.B);

						sim += (cr + cg + cb) / 3.0;
					}
				}

				sim /= 255.0;
				sim /= img.Height * img.Width;
			}

			return 1 - sim;
		}