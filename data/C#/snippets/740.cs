public void Update(ModelBase model)
		{
			if(model != null)
				this.Update(model.GetChangedProperties());
		}