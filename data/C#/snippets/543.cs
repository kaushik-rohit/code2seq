public Stream CreateVideoThumbnail(string localFilePath)
		{
			var thumb = global::Android.Media.ThumbnailUtils.CreateVideoThumbnail(localFilePath, global::Android.Provider.ThumbnailKind.FullScreenKind);
			var stream = new MemoryStream();

			thumb.Compress(Bitmap.CompressFormat.Png, 0, stream);
			stream.Seek(0, SeekOrigin.Begin);

			return stream;
		}