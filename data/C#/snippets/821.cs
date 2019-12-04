protected virtual void SetPalette(Image value)
		{
			if (dragListener!=null)
			{
				dragListener.OnDragEvent.RemoveListener(OnDrag);
			}
			palette = value;
			if (palette!=null)
			{
				paletteRect = palette.transform as RectTransform;
				dragListener = palette.GetComponent<OnDragListener>();
				if (dragListener==null)
				{
					dragListener = palette.gameObject.AddComponent<OnDragListener>();
				}
				dragListener.OnDragEvent.AddListener(OnDrag);
				UpdateMaterial();
			}
			else
			{
				paletteRect = null;
			}
		}