public void Execute()
        {
            bool newLine = true;
            while (true)
            {
                var token = _runEnvironment.CurrentLine.NextToken();
                if ((token.Seperator == TokenType.Colon)
                    || (token.Statement == TokenType.Else)
                    || (token.Seperator == TokenType.EndOfLine))
                {
                    if (newLine)
                    {
                        _teletype.NewLine();
                    }

                    _runEnvironment.CurrentLine.PushToken(token);
                    return;
                }

                if ((token.Statement == TokenType.Tab) || (token.Statement == TokenType.Space))
                {
                    short value = _expressionEvaluator.GetExpression().ValueAsShort();
                    if (_runEnvironment.CurrentLine.NextToken().Seperator != TokenType.CloseBracket)
                    {
                        throw new Exceptions.SyntaxErrorException();
                    }

                    if (token.Statement == TokenType.Tab)
                    {
                        _teletype.Tab(value);
                    }
                    else
                    {
                        _teletype.Space(value);
                    }
                }
                else if ((token.Seperator == TokenType.Semicolon) || (token.Seperator == TokenType.Comma))
                {
                    newLine = false;
                    if (token.Seperator == TokenType.Comma)
                    {
                        _teletype.NextComma();
                    }
                }
                else
                {
                    newLine = true;
                    _runEnvironment.CurrentLine.PushToken(token);
                    _teletype.Write(_expressionEvaluator.GetExpression().ToString());
                }
            }
        }