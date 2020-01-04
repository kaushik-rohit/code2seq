public static void generate(String content, int width, int height, String imageType, OutputStream out) {
		final BufferedImage image = generate(content, width, height);
		ImgUtil.write(image, imageType, out);
	}