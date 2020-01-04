protected virtual void UpdateViewReal()
		{
			inUpdateMode = true;
			
			//set slider value
			if (slider!=null)
			{
				slider.value = GetSliderValue();
			}
			
			//set slider colors
			if (sliderBackground!=null)
			{
				var colors = GetSliderColors();
				sliderBackground.material.SetColor("_ColorBottom", colors[0]);
				sliderBackground.material.SetColor("_ColorTop", colors[1]);
			}
			
			//set palette drag position
			if ((paletteCursor!=null) && (palette!=null) && (paletteRect!=null))
			{
				var coords = GetPaletteCoords();
				var size = paletteRect.rect.size;

				paletteCursor.localPosition = new Vector3(coords.x * size.x, - (1 - coords.y) * size.y, 0);
			}
			
			//set palette colors
			if (palette!=null)
			{
				var colors = GetPaletteColors();

				palette.material.SetColor("_ColorLeft", colors[0]);
				palette.material.SetColor("_ColorRight", colors[1]);
				palette.material.SetColor("_ColorBottom", colors[2]);
				palette.material.SetColor("_ColorTop", colors[3]);
			}
			
			inUpdateMode = false;
		}