protected int GetSliderValue()
		{
			switch (paletteMode)
			{
				case ColorPickerPaletteMode.Hue:
					return currentColorHSV.H;
				case ColorPickerPaletteMode.Saturation:
					return currentColorHSV.S;
				case ColorPickerPaletteMode.Value:
					return currentColorHSV.V;
				default:
					return 0;
			}
		}