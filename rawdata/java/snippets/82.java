public static BufferedImage pressText(Image srcImage, String pressText, Color color, Font font, int x, int y, float alpha) {
		return Img.from(srcImage).pressText(pressText, color, font, x, y, alpha).getImg();
	}