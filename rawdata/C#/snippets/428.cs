public void Remove(string key)
		{
			PropertiesDictionary dictionary = GetProperties(false);
			if (dictionary != null)
			{
				dictionary.Remove(key);
			}
		}