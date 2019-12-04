public virtual void Start()
		{
			if (isStarted)
			{
				return ;
			}
			isStarted = true;
			
			Palette = palette;
			Slider = slider;
			SliderBackground = sliderBackground;
		}