protected char Read()
		{
			var ch = Peek();
			sourcePosition++;
			if (ch != NullChar)
			{
				CurrentTokenChars.Append(ch);

				if (ch == '\r' && Peek() != '\n')
				{
					CurrentLine++;
					PositionOnLine = 0;
				}
				else if (ch == '\n')
				{
					CurrentLine++;
					PositionOnLine = 0;
				}
				PositionOnLine++;
				position++;
			}

			return ch;
		}