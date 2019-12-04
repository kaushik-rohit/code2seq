Font GetCachedFont (string fontFamily, double fontSize, double fontWeight)
        {
			if (String.IsNullOrEmpty (fontFamily))
				fontFamily = Font.SystemFont.Family;

			var key = fontFamily + ' ' + GetFontWeight(fontWeight) + ' ' + fontSize.ToString ("0.###");

            Font font;
			if (!fonts.TryGetValue (key, out font))
				fonts [key] = Font.FromName (fontFamily).WithWeight (GetFontWeight (fontWeight)).WithSize (fontSize);

			return fonts [key];
        }