public static Color ColorDifference(Color a, Color b)
		{
			int cr = a.R - b.R;
			int cg = a.G - b.G;
			int cb = a.B - b.B;
			if(cr < 0)
			{
				cr += 255;
			}
			if(cg < 0)
			{
				cg += 255;
			}
			if(cb < 0)
			{
				cb += 255;
			}
			return Color.FromArgb(cr, cg, cb);
		}