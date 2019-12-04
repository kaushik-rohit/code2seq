protected virtual void ValueChanged()
		{
			if (inUpdateMode)
			{
				return ;
			}
			currentColorHSV = GetColor();

			OnChangeHSV.Invoke(currentColorHSV);
		}