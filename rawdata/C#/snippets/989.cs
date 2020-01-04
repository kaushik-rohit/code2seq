protected virtual void OnSelectionNullStatusChanged(EventArgs e)
		{
			if (SelectionNullStatusChanged != null)
				SelectionNullStatusChanged(this, e);
		}