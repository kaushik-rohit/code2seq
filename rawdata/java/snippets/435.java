public static void pressText(ImageInputStream srcStream, ImageOutputStream destStream, String pressText, Color color, Font font, int x, int y, float alpha) {
		pressText(read(srcStream), destStream, pressText, color, font, x, y, alpha);
	}