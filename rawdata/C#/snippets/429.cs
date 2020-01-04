public void Clear()
		{
			PropertiesDictionary dictionary = GetProperties(false);
			if (dictionary != null)
			{
				dictionary.Clear();
			}
		}