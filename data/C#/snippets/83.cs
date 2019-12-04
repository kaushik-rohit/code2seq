public static bool IsActionDefined(int body, int action, int direction)
		{
			Translate(ref body);
			int fileType = BodyConverter.Convert(ref body);
			FileIndex fileIndex;
			int index;
			GetFileIndex(body, action, direction, fileType, out fileIndex, out index);

			int length, extra;
			bool patched;
			bool valid = fileIndex.Valid(index, out length, out extra, out patched);
			if ((!valid) || (length < 1))
			{
				return false;
			}
			return true;
		}