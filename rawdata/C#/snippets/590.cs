private void Read (ReadStyle propertiesStyle)
		{
			Mode = AccessMode.Read;
			try {
				ImageTag = new CombinedImageTag (TagTypes.TiffIFD);

				ReadFile ();

				TagTypesOnDisk = TagTypes;

				if (propertiesStyle != ReadStyle.None)
					properties = ExtractProperties ();

			} finally {
				Mode = AccessMode.Closed;
			}
		}