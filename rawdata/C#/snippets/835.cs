protected Color[] GetPaletteColors()
		{
			switch (paletteMode)
			{
				case ColorPickerPaletteMode.Hue:
					return new Color[] {
						new Color(currentColorHSV.H / 359f / 2f, 0f, 0f, 1f),
						new Color(currentColorHSV.H / 359f / 2f, 1f, 0f, 1f),
						new Color(currentColorHSV.H / 359f / 2f, 0f, 0f, 1f),
						new Color(currentColorHSV.H / 359f / 2f, 0f, 1f, 1f),
					};
				case ColorPickerPaletteMode.Saturation:
					return new Color[] {
						new Color(0f, currentColorHSV.S / 255f / 2f, 0f, 1f),
						new Color(1f, currentColorHSV.S / 255f / 2f, 0f, 1f),
						new Color(0f, currentColorHSV.S / 255f / 2f, 0f, 1f),
						new Color(0f, currentColorHSV.S / 255f / 2f, 1f, 1f),
					};
				case ColorPickerPaletteMode.Value:
					return new Color[] {
						new Color(0f, 0f, currentColorHSV.V / 255f / 2f, 1f),
						new Color(1f, 0f, currentColorHSV.V / 255f / 2f, 1f),
						new Color(0f, 0f, currentColorHSV.V / 255f / 2f, 1f),
						new Color(0f, 1f, currentColorHSV.V / 255f / 2f, 1f),
					};
				default:
					return new Color[] {
						new Color(0f, 0f, 1f, 1f),
						new Color(1f, 1f, 1f, 1f),
						new Color(0f, 0, 1f, 1f),
						new Color(1f, 1f, 1f, 1f),
					};
			}
		}