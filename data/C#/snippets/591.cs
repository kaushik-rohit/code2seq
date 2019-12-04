private void ReadFile ()
		{
			// A RW2 file starts with a Tiff header followed by a RW2 header
			uint first_ifd_offset = ReadHeader ();
			uint raw_ifd_offset = ReadAdditionalRW2Header ();

			ReadIFD (first_ifd_offset, 3);
			ReadIFD (raw_ifd_offset, 1);
		}