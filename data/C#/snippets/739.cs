public void Update(IDictionary<string, object> properties)
		{
			if(properties == null)
				return;

			foreach(var property in properties)
			{
				this.SetPropertyValue(property.Key, property.Value);
			}
		}