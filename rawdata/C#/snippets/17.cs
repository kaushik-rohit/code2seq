public static Color IdentifyColor(
			ImageData img,
			Dictionary<Color, List<double>> statReference,
			int left = 0,
			int top = 0,
			int width = -1,
			int height = -1)
		{
			double[] av = AverageRgbValues(img, left, top, width, height);

			double bestScore = 255;

			Color foo = Color.White;

			foreach(KeyValuePair<Color, List<double>> item in statReference)
			{
				double currentScore = Math.Pow((item.Value[0] / 255.0) - (av[0] / 255.0), 2)
									+ Math.Pow((item.Value[1] / 255.0) - (av[1] / 255.0), 2)
									+ Math.Pow((item.Value[2] / 255.0) - (av[2] / 255.0), 2);
				if(currentScore < bestScore)
				{
					foo = item.Key;
					bestScore = currentScore;
				}
			}

			return foo;
		}