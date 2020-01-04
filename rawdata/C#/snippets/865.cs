public FTBitmap Copy(Library library)
		{
			if (disposed)
				throw new ObjectDisposedException("FTBitmap", "Cannot access a disposed object.");

			if (library == null)
				throw new ArgumentNullException("library");

			FTBitmap newBitmap = new FTBitmap(library);
			IntPtr bmpRef = newBitmap.reference;
			Error err = FT.FT_Bitmap_Copy(library.Reference, Reference, bmpRef);
			newBitmap.Reference = bmpRef;

			if (err != Error.Ok)
				throw new FreeTypeException(err);

			return newBitmap;
		}