protected virtual void UpdateMaterial()
		{
			if ((paletteShader!=null) && (palette!=null))
			{
				palette.material = new Material(paletteShader);
			}
			
			if ((sliderShader!=null) && (sliderBackground!=null))
			{
				sliderBackground.material = new Material(sliderShader);
			}
			
			UpdateViewReal();
		}