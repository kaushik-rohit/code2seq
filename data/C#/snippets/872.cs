public FTBitmap Convert(Library library, int alignment)
		{
			if (disposed)
				throw new ObjectDisposedException("FTBitmap", "Cannot access a disposed object.");

			if (library == null)
				throw new ArgumentNullException("library");

			FTBitmap newBitmap = new FTBitmap(library);
			IntPtr bmpRef = newBitmap.reference;
			Error err = FT.FT_Bitmap_Convert(library.Reference, Reference, bmpRef, alignment);
			newBitmap.Reference = bmpRef;

			if (err != Error.Ok)
				throw new FreeTypeException(err);

			return newBitmap;
		}