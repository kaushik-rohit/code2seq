public Bitmap ToGdipBitmap(Color color)
		{
			if (disposed)
				throw new ObjectDisposedException("FTBitmap", "Cannot access a disposed object.");

			if (rec.width == 0 || rec.rows == 0)
				throw new InvalidOperationException("Invalid image size - one or both dimensions are 0.");

			//TODO deal with negative pitch
			switch (rec.pixel_mode)
			{
				case PixelMode.Mono:
				{
					Bitmap bmp = new Bitmap(rec.width, rec.rows, PixelFormat.Format1bppIndexed);
					var locked = bmp.LockBits(new Rectangle(0, 0, rec.width, rec.rows), ImageLockMode.ReadWrite, PixelFormat.Format1bppIndexed);
					for (int i = 0; i < rec.rows; i++)
						PInvokeHelper.Copy(Buffer, i * rec.pitch, locked.Scan0, i * locked.Stride, locked.Stride);
					bmp.UnlockBits(locked);

					ColorPalette palette = bmp.Palette;
					palette.Entries[0] = Color.FromArgb(0, color);
					palette.Entries[1] = Color.FromArgb(255, color);

					bmp.Palette = palette;
					return bmp;
				}

				case PixelMode.Gray4:
				{
					Bitmap bmp = new Bitmap(rec.width, rec.rows, PixelFormat.Format4bppIndexed);
					var locked = bmp.LockBits(new Rectangle(0, 0, rec.width, rec.rows), ImageLockMode.ReadWrite, PixelFormat.Format4bppIndexed);
					for (int i = 0; i < rec.rows; i++)
						PInvokeHelper.Copy(Buffer, i * rec.pitch, locked.Scan0, i * locked.Stride, locked.Stride);
					bmp.UnlockBits(locked);

					ColorPalette palette = bmp.Palette;
					for (int i = 0; i < palette.Entries.Length; i++)
					{
						float a = (i * 17) / 255f;
						palette.Entries[i] = Color.FromArgb(i * 17, (int)(color.R * a), (int)(color.G * a), (int)(color.B * a));
					}

					bmp.Palette = palette;
					return bmp;
				}

				case PixelMode.Gray:
				{
					Bitmap bmp = new Bitmap(rec.width, rec.rows, PixelFormat.Format8bppIndexed);
					var locked = bmp.LockBits(new Rectangle(0, 0, rec.width, rec.rows), ImageLockMode.ReadWrite, PixelFormat.Format8bppIndexed);
					for (int i = 0; i < rec.rows; i++)
						PInvokeHelper.Copy(Buffer, i * rec.pitch, locked.Scan0, i * locked.Stride, locked.Stride);
					bmp.UnlockBits(locked);

					ColorPalette palette = bmp.Palette;
					for (int i = 0; i < palette.Entries.Length; i++)
					{
						float a = i / 255f;
						palette.Entries[i] = Color.FromArgb(i, (int)(color.R * a), (int)(color.G * a), (int)(color.B * a));
					}

					bmp.Palette = palette;
					return bmp;
				}

				case PixelMode.Lcd:
				{
					//TODO apply color
					int bmpWidth = rec.width / 3;
					Bitmap bmp = new Bitmap(bmpWidth, rec.rows, PixelFormat.Format24bppRgb);
					var locked = bmp.LockBits(new Rectangle(0, 0, bmpWidth, rec.rows), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
					for (int i = 0; i < rec.rows; i++)
						PInvokeHelper.Copy(Buffer, i * rec.pitch, locked.Scan0, i * locked.Stride, locked.Stride);
					bmp.UnlockBits(locked);

					return bmp;
				}
				/*case PixelMode.VerticalLcd:
				{
					int bmpHeight = rec.rows / 3;
					Bitmap bmp = new Bitmap(rec.width, bmpHeight, PixelFormat.Format24bppRgb);
					var locked = bmp.LockBits(new Rectangle(0, 0, rec.width, bmpHeight), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
					for (int i = 0; i < bmpHeight; i++)
						PInvokeHelper.Copy(Buffer, i * rec.pitch, locked.Scan0, i * locked.Stride, rec.width);
					bmp.UnlockBits(locked);

					return bmp;
				}*/

				default:
					throw new InvalidOperationException("System.Drawing.Bitmap does not support this pixel mode.");
			}
		}