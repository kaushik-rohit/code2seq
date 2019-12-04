public static Frame[] GetAnimation(
			int body, int action, int direction, ref int hue, bool preserveHue, bool FirstFrame)
		{
			if (preserveHue)
			{
				Translate(ref body);
			}
			else
			{
				Translate(ref body, ref hue);
			}

			int fileType = BodyConverter.Convert(ref body);

			FileIndex fileIndex;
			int index;
			GetFileIndex(body, action, direction, fileType, out fileIndex, out index);

			int length, extra;
			bool patched;
			Stream stream = fileIndex.Seek(index, out length, out extra, out patched);

			if (stream == null)
			{
				return null;
			}
			if (m_StreamBuffer == null || m_StreamBuffer.Length < length)
			{
				m_StreamBuffer = new byte[length];
			}
			stream.Read(m_StreamBuffer, 0, length);
			m_MemoryStream = new MemoryStream(m_StreamBuffer, false);

			bool flip = direction > 4;
			Frame[] frames;
			using (var bin = new BinaryReader(m_MemoryStream))
			{
				var palette = new ushort[0x100];

				for (int i = 0; i < 0x100; ++i)
				{
					palette[i] = (ushort)(bin.ReadUInt16() ^ 0x8000);
				}

				var start = (int)bin.BaseStream.Position;
				int frameCount = bin.ReadInt32();

				var lookups = new int[frameCount];

				for (int i = 0; i < frameCount; ++i)
				{
					lookups[i] = start + bin.ReadInt32();
				}

				bool onlyHueGrayPixels = (hue & 0x8000) != 0;

				hue = (hue & 0x3FFF) - 1;

				Hue hueObject;

				if (hue >= 0 && hue < Hues.List.Length)
				{
					hueObject = Hues.List[hue];
				}
				else
				{
					hueObject = null;
				}

				if (FirstFrame)
				{
					frameCount = 1;
				}
				frames = new Frame[frameCount];

				for (int i = 0; i < frameCount; ++i)
				{
					bin.BaseStream.Seek(lookups[i], SeekOrigin.Begin);
					frames[i] = new Frame(palette, bin, flip);

					if (hueObject != null)
					{
						if (frames[i] != null)
						{
							if (frames[i].Bitmap != null)
							{
								hueObject.ApplyTo(frames[i].Bitmap, onlyHueGrayPixels);
							}
						}
					}
				}
				bin.Close();
			}
			m_MemoryStream.Close();
			return frames;
		}