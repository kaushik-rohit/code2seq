protected virtual void SetPaletteMode(ColorPickerPaletteMode value)
		{
			paletteMode = value;
			
			bool is_active = paletteMode==ColorPickerPaletteMode.Hue
				|| paletteMode==ColorPickerPaletteMode.Saturation
					|| paletteMode==ColorPickerPaletteMode.Value;
			gameObject.SetActive(is_active);
			slider.maxValue = (paletteMode==ColorPickerPaletteMode.Hue) ? 359 : 255;
			
			if (is_active)
			{
				UpdateView();
			}
		}