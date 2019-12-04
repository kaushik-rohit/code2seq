public static bool ColorsSimilar(Color one, Color two, uint tolerance)
		{
			if(Math.Abs(one.R - two.R) > tolerance)
			{
				return false;
			}
			if(Math.Abs(one.G - two.G) > tolerance)
			{
				return false;
			}
			if(Math.Abs(one.B - two.B) > tolerance)
			{
				return false;
			}
			return true;
		}