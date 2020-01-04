protected Color[] GetSliderColors()
		{
			switch (paletteMode)
			{
				case ColorPickerPaletteMode.Hue:
					return new Color[] {
						new Color(0f, 1f, 1f, 1f),
						new Color(1f, 1f, 1f, 1f),
					};
				case ColorPickerPaletteMode.Saturation:
					return new Color[] {
					new Color(currentColorHSV.H / 359f, 0f, Mathf.Max(ColorPicker.ValueLimit, currentColorHSV.V) / 255f, 1f),
					new Color(currentColorHSV.H / 359f, 1f, Mathf.Max(ColorPicker.ValueLimit, currentColorHSV.V) / 255f, 1f),
					};
				case ColorPickerPaletteMode.Value:
					return new Color[] {
						new Color(currentColorHSV.H / 359f, currentColorHSV.S / 255f, 0f, 1f),
						new Color(currentColorHSV.H / 359f, currentColorHSV.S / 255f, 1f, 1f),
					};
				default:
					return new Color[] {
						new Color(0f, 0f, 0f, 1f),
						new Color(1f, 1f, 1f, 1f)
					};
			}
		}