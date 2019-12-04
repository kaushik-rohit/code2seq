internal PropertiesDictionary GetProperties(bool create)
		{
			PropertiesDictionary properties = (PropertiesDictionary)System.Threading.Thread.GetData(s_threadLocalSlot);
			if (properties == null && create)
			{
				properties  = new PropertiesDictionary();
				System.Threading.Thread.SetData(s_threadLocalSlot, properties);
			}
			return properties;
		}