private Properties ExtractProperties ()
		{
			int width = 0, height = 0;

			IFDTag tag = GetTag (TagTypes.TiffIFD) as IFDTag;
			IFDStructure structure = tag.Structure;

			width = (int) (structure.GetLongValue (0, 0x07) ?? 0);
			height = (int) (structure.GetLongValue (0, 0x06) ?? 0);

			var vendor = ImageTag.Make;
			if (vendor == "LEICA")
				vendor = "Leica";
			var desc = String.Format ("{0} RAW File", vendor);

			if (width > 0 && height > 0) {
				return new Properties (TimeSpan.Zero, new Codec (width, height, desc));
			}

			return null;
		}