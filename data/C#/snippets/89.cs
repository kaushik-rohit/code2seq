public static bool IsAnimDefinied(int body, int action, int dir, int fileType)
		{
			FileIndex fileIndex;
			int index;
			GetFileIndex(body, action, dir, fileType, out fileIndex, out index);

			int length, extra;
			bool patched;
			Stream stream = fileIndex.Seek(index, out length, out extra, out patched);
			bool def = true;
			if ((stream == null) || (length == 0))
			{
				def = false;
			}
			if (stream != null)
			{
				stream.Close();
			}
			return def;
		}