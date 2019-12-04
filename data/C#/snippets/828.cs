protected ColorHSV GetColor()
		{
			var coords = GetCursorCoords();
			
			var s = Mathf.RoundToInt(slider.value);
			var x = coords.x;
			var y = coords.y;

			switch (paletteMode)
			{
				case ColorPickerPaletteMode.Hue:
					return new ColorHSV(s, Mathf.RoundToInt(y * 255f), Mathf.RoundToInt(x * 255f), currentColorHSV.A);
				case ColorPickerPaletteMode.Saturation:
					return new ColorHSV(Mathf.RoundToInt(x * 359f), s, Mathf.RoundToInt(y * 255f), currentColorHSV.A);
				case ColorPickerPaletteMode.Value:
					return new ColorHSV(Mathf.RoundToInt(x * 359f), Mathf.RoundToInt(y * 255f), s, currentColorHSV.A);
				default:
					return currentColorHSV;
			}
		}