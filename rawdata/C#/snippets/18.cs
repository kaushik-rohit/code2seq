public static string IdentifyImage(ImageData img, Dictionary<string, ImageData> statReference)
		{
			double similar = 0.0;
			string keyword = string.Empty;
			foreach(KeyValuePair<string, ImageData> item in statReference)
			{
				// exakte übereinstimmung der Größen ermöglicht einen simplen vergleich
				if((img.Width == item.Value.Width) && (img.Height == item.Value.Height))
				{
					double s = Similarity(img, item.Value);
					if(s > similar)
					{
						keyword = item.Key;
						similar = s;
					}
				}
				else
				{
					if((img.Width > item.Value.Width) && (img.Height > item.Value.Height))
					{
						// im größeren suchen
						for(int column = 0; column < img.Width - item.Value.Width; column++)
						{
							for(int row = 0; row < img.Height - item.Value.Height; row++)
							{
								double s = Similarity(img, item.Value, 0, 0, item.Value.Width, item.Value.Height, column, row);
								if(s > similar)
								{
									keyword = item.Key;
									similar = s;
								}
							}
						}
					}
				}
			}

			return keyword;
		}