private JSlider getSliderMaxDepth() {
		if (sliderMaxDepth == null) {
			sliderMaxDepth = new JSlider();
			sliderMaxDepth.setMaximum(19);
			sliderMaxDepth.setMinimum(0);
			sliderMaxDepth.setMinorTickSpacing(1);
			sliderMaxDepth.setPaintTicks(true);
			sliderMaxDepth.setPaintLabels(true);
			sliderMaxDepth.setName("");
			sliderMaxDepth.setMajorTickSpacing(1);
			sliderMaxDepth.setSnapToTicks(true);
			sliderMaxDepth.setPaintTrack(true);
		}
		return sliderMaxDepth;
	}