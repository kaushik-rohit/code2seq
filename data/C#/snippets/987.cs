private bool IsNullChange(T selected, T value)
		{
			if (selected != null && value == null)
				return true;
			else if (selected == null && value != null)
				return true;
			else
				return false;
		}