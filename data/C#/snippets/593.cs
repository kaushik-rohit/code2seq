private uint ReadAdditionalRW2Header ()
		{
			// RW2 Header
			//
			// Seems to be 16 bytes, no idea on the meaning of these.

			ByteVector header = ReadBlock (16);

			if (header.Count != 16)
				throw new CorruptFileException ("Unexpected end of RW2 header");

			return (uint) Tell;
		}