protected void SkipWhitespace(bool allowEndLine = true)
		{
			while (char.IsWhiteSpace(Peek()) && (allowEndLine || (Peek() != '\r' && Peek() != '\n')))
			{
				if (Read() == NullChar)
				{
					break;
				}
			}
			if (DistanceSinceLastToken > 0)
			{
				CreateToken(WhiteSpaceTokenType);
			}
		}