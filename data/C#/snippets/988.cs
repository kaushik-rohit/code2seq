protected virtual void OnSelectionChanged(DataEventArgs<T> e)
		{
			if (SelectionChanged != null)
				SelectionChanged(this, e);
		}