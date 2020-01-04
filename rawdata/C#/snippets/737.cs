public bool HasChanges(params string[] names)
		{
			var isChanged = _changedProperties != null && _changedProperties.Count > 0;

			if(names == null || names.Length == 0)
				return isChanged;

			if(isChanged)
			{
				foreach(var name in names)
				{
					if(_changedProperties.ContainsKey(name))
						return true;
				}
			}

			return false;
		}