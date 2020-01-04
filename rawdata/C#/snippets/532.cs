protected bool TokenizeInternal(string sourceText, Func<bool> readFunction)
		{
			this.sourceText = sourceText;

			try
			{
				position = 0;
				CurrentLine = 1;
				PositionOnLine = 0;
				LastToken = null;
				LastTokenPosition = 0;
				Tokens.Clear();
				CurrentTokenChars.Clear();

				return readFunction();
			}
			catch (Exception ex) when (ex.Message == "Assertion failed!")
			{
				return false;
			}
		}