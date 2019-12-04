public static bool PerformRectangularPaste(TextArea textArea, TextViewPosition startPosition, string text, bool selectInsertedText)
		{
			if (textArea == null)
				throw new ArgumentNullException("textArea");
			if (text == null)
				throw new ArgumentNullException("text");
			int newLineCount = text.Count(c => c == '\n'); // TODO might not work in all cases, but single \r line endings are really rare today.
			TextLocation endLocation = new TextLocation(startPosition.Line + newLineCount, startPosition.Column);
			if (endLocation.Line <= textArea.Document.LineCount) {
				int endOffset = textArea.Document.GetOffset(endLocation);
				if (textArea.Selection.EnableVirtualSpace || textArea.Document.GetLocation(endOffset) == endLocation) {
					RectangleSelection rsel = new RectangleSelection(textArea, startPosition, endLocation.Line, GetXPos(textArea, startPosition));
					rsel.ReplaceSelectionWithText(text);
					if (selectInsertedText && textArea.Selection is RectangleSelection) {
						RectangleSelection sel = (RectangleSelection)textArea.Selection;
						textArea.Selection = new RectangleSelection(textArea, startPosition, sel.endLine, sel.endXPos);
					}
					return true;
				}
			}
			return false;
		}