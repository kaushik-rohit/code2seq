FontWeight GetFontWeight (double weight)
		{
			if (weight < 300)
				return FontWeight.Ultralight;
			if (weight < 400)
				return FontWeight.Light;
			if (weight < 600)
				return FontWeight.Normal;
			if (weight < 700)
				return FontWeight.Semibold;
			if (weight < 800)
				return FontWeight.Bold;
			return FontWeight.Ultrabold;
		}