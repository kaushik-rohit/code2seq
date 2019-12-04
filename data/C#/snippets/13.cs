public static Color AverageColor(ImageData img, int left = 0, int top = 0, int width = -1, int height = -1)
		{
			double[] retvar = AverageRgbValues(img, left, top, width, height);
			return Color.FromArgb(Convert.ToInt32(retvar[0]), Convert.ToInt32(retvar[1]), Convert.ToInt32(retvar[2]));
		}