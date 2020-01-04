protected virtual void SetSlider(Slider value)
		{
			if (slider!=null)
			{
				slider.onValueChanged.RemoveListener(SliderValueChanged);
			}
			slider = value;
			if (slider!=null)
			{
				slider.onValueChanged.AddListener(SliderValueChanged);
			}
		}