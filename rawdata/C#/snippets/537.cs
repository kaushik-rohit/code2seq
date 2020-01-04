protected TToken CreateToken(TTokenType type, int charsFromEndToSkip = 0, Func<TToken, TokenError> errorProvider = null)
		{
			var t = NewToken();
			t.LineNumber = CurrentLine;
			t.ColumnNumber = Math.Max(0, PositionOnLine - DistanceSinceLastToken - 1);
			t.StartPosition = LastTokenPosition;
			t.Length = DistanceSinceLastToken - charsFromEndToSkip;
			t.Type = type;
			t.Text = CurrentTokenChars.ToString().Substring(0, DistanceSinceLastToken - charsFromEndToSkip);
			Tokens.Add(t);
			if (errorProvider != null)
			{
				t.Error = errorProvider(t);
			}

			CurrentTokenChars.Remove(0, t.Length);
			LastTokenPosition = position - charsFromEndToSkip;

			OnTokenFound(t);

			return LastToken = t;
		}