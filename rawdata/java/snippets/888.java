public static void pressText(Image srcImage, File destFile, String pressText, Color color, Font font, int x, int y, float alpha) throws IORuntimeException {
		write(pressText(srcImage, pressText, color, font, x, y, alpha), destFile);
	}