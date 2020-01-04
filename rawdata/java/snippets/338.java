public static Font getFont (int style, Size size) {
		return getFont(getDefaultFont(), size).deriveFont(style);
	}