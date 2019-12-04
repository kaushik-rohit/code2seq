public static string GetFileName(int body)
		{
			Translate(ref body);
			int fileType = BodyConverter.Convert(ref body);

			if (fileType == 1)
			{
				return "anim.mul";
			}
			else
			{
				return String.Format("anim{0}.mul", fileType);
			}
		}