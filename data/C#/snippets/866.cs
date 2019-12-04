public void Embolden(Library library, Fixed26Dot6 xStrength, Fixed26Dot6 yStrength)
		{
			if (disposed)
				throw new ObjectDisposedException("FTBitmap", "Cannot access a disposed object.");

			if (library == null)
				throw new ArgumentNullException("library");

			Error err = FT.FT_Bitmap_Embolden(library.Reference, Reference, (IntPtr)xStrength.Value, (IntPtr)yStrength.Value);

			if (err != Error.Ok)
				throw new FreeTypeException(err);
		}