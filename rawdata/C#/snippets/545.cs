public Stream CreateImageThumbnail(Stream original, int width, int height, int quality)
		{
			// Load the bitmap
			Bitmap originalImage = BitmapFactory.DecodeStream(original);

			float oldWidth = originalImage.Width;
			float oldHeight = originalImage.Height;
			float scaleFactor = 0f;

			if (oldWidth > oldHeight)
			{
				scaleFactor = width / oldWidth;
			}
			else
			{
				scaleFactor = height / oldHeight;
			}

			float newHeight = oldHeight * scaleFactor;
			float newWidth = oldWidth * scaleFactor;

			Bitmap resizedImage = Bitmap.CreateScaledBitmap(originalImage, (int)newWidth, (int)newHeight, false);

			MemoryStream ms = new MemoryStream();
			resizedImage.Compress(Bitmap.CompressFormat.Jpeg, quality, ms);

			return ms;
		}