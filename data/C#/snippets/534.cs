protected void ReadTextUntilNewLine(TTokenType tokenType, params char[] stopChars)
		{
			int lastNonwhitespaceDistance = 0;

			while (Peek() != '\r' && Peek() != '\n' && !stopChars.Contains(Peek()))
			{
				lastNonwhitespaceDistance = char.IsWhiteSpace(Peek()) ? lastNonwhitespaceDistance + 1 : 0;
				if (Read() == NullChar)
				{
					break;
				}
			}
			if (DistanceSinceLastToken > 0)
			{
				CreateToken(tokenType, lastNonwhitespaceDistance);
			}

			if (Peek() == '\r')
			{
				// \r can be followed by \n which is still one new line
				Read();
			}
			if (Peek() == '\n')
			{
				Read();
			}

			if (DistanceSinceLastToken > 0)
			{
				CreateToken(WhiteSpaceTokenType);
			}
		}