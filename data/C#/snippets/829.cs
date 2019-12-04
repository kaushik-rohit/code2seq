protected Vector2 GetCursorCoords()
		{
			var coords = paletteCursor.localPosition;
			var size = paletteRect.rect.size;
			
			var x = (coords.x / size.x);
			var y = coords.y / size.y + 1;

			return new Vector2(x, y);
		}