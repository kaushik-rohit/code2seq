protected Vector2 GetPaletteCoords()
		{
			switch (paletteMode)
			{
				case ColorPickerPaletteMode.Hue:
					return new Vector2(currentColorHSV.V / 255f, currentColorHSV.S / 255f);
				case ColorPickerPaletteMode.Saturation:
					return new Vector2(currentColorHSV.H / 359f, currentColorHSV.V / 255f);
				case ColorPickerPaletteMode.Value:
					return new Vector2(currentColorHSV.H / 359f, currentColorHSV.S / 255f);
				default:
					return new Vector2(0, 0);
			}
		}