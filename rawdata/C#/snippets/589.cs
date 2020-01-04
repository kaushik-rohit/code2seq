public override TagLib.Tag GetTag (TagLib.TagTypes type,
		                                   bool create)
		{
			TagLib.Tag tag = base.GetTag (type, false);
			if (tag != null) {
				return tag;
			}

			if (!create || (type & ImageTag.AllowedTypes) == 0)
				return null;

			if (type != TagTypes.TiffIFD)
				return base.GetTag (type, create);

			ImageTag new_tag = new IFDTag (this);
			ImageTag.AddTag (new_tag);
			return new_tag;
		}