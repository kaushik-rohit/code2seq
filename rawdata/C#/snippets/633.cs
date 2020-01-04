public static int EstimatePasswordStrength(
            [NotNull] string password,
            out IDictionary<Addition, int> additions)
        {
            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentException(Properties.Strings.PasswordNotSet);
            }

            var passwordLower = password.ToLowerInvariant();
            int score;
            int alphasUpperCount = 0, alphasLowerCount = 0, digitsCount = 0, symbolsCount = 0, middleCharsCount = 0,
                requirements = 0, alphasOnlyCount = 0, numbersOnlyCount = 0, uniqueCharsCount = 0, repeatCharsCount = 0,
                consequenceAlphasUpperCount = 0, consequenceAlphasLowerCount = 0, consequenceDigitsCount = 0, consequenceSymbolsCount = 0, consequenceCharsTypeCount = 0,
                sequenceAlphasCount = 0, sequenceNumbersCount = 0, sequenceSymbolsCount = 0, sequenceCharsCount = 0, requiredCharsCount = 0;
            double repeatIncrement = 0;
            int tempAlphaUpperIndex = -1, tempAlphaLowerIndex = -1, tempNumberIndex = -1, tempSymbolIndex = -1;

            const int FactorMiddleChar = 2, FactorConsequenceAlphaUpper = 2, FactorConsequenceAlphaLower = 2, FactorConsequenceNumber = 2;
            const int FactorSequenceAlpha = 3, FactorSequenceNumber = 3, FactorSequenceSymbol = 3;
            const int FactorLength = 4, FactorNumber = 4;
            const int FactorSymbol = 6;
            const string PoolAlphas = "abcdefghijklmnopqrstuvwxyz";
            const string PoolNumerics = "01234567890";
            const string PoolSymbols = ")!@#$%^&*()";
            const int MinimumPasswordLength = 8;

            score = password.Length * FactorLength;

            // Loop through password to check for Symbol, Numeric, Lowercase and Uppercase pattern matches.
            for (var a = 0; a < password.Length; a++)
            {
                if (char.IsUpper(password[a]))
                {
                    if (tempAlphaUpperIndex > -1 && tempAlphaUpperIndex + 1 == a)
                    {
                        consequenceAlphasUpperCount++;
                        consequenceCharsTypeCount++;
                    }
                    tempAlphaUpperIndex = a;
                    alphasUpperCount++;
                }
                else if (char.IsLower(password[a]))
                {
                    if (tempAlphaLowerIndex > -1 && tempAlphaLowerIndex + 1 == a)
                    {
                        consequenceAlphasLowerCount++;
                        consequenceCharsTypeCount++;
                    }
                    tempAlphaLowerIndex = a;
                    alphasLowerCount++;
                }
                else if (char.IsNumber(password[a]))
                {
                    if (a > 0 && a < password.Length - 1)
                    {
                        middleCharsCount++;
                    }
                    if (tempNumberIndex > -1 && tempNumberIndex + 1 == a)
                    {
                        consequenceDigitsCount++;
                        consequenceCharsTypeCount++;
                    }
                    tempNumberIndex = a;
                    digitsCount++;
                }
                else if (Regex.IsMatch(password[a].ToString(), @"[^a-zA-Z0-9_]"))
                {
                    if (a > 0 && a < (password.Length - 1))
                    {
                        middleCharsCount++;
                    }
                    if (tempSymbolIndex > -1 && tempSymbolIndex + 1 == a)
                    {
                        consequenceSymbolsCount++;
                        consequenceCharsTypeCount++;
                    }
                    tempSymbolIndex = a;
                    symbolsCount++;
                }

                // Internal loop through password to check for repeat characters.
                var charExists = false;
                for (var b = 0; b < password.Length; b++)
                {
                    // Repeat character exists.
                    if (password[a] == password[b] && a != b)
                    {
                        charExists = true;
                        /* Calculate icrement deduction based on proximity to identical characters
                           Deduction is incremented each time a new match is discovered
                           Deduction amount is based on total password length divided by the
                           difference of distance between currently selected match */
                        repeatIncrement += Math.Abs(password.Length / (b - a));
                    }
                }
                if (charExists)
                {
                    repeatCharsCount++;
                    uniqueCharsCount = password.Length - repeatCharsCount;
                    repeatIncrement = uniqueCharsCount > 0 ? Math.Ceiling(repeatIncrement / uniqueCharsCount) : Math.Ceiling(repeatIncrement);
                }
            }

            // Check for sequential alpha string patterns (forward and reverse).
            for (var s = 0; s < PoolAlphas.Length - 3; s++)
            {
                var forward = PoolAlphas.Substring(s, 3);
                var reverse = Reverse(forward);
                if (passwordLower.IndexOf(forward, StringComparison.Ordinal) != -1 ||
                    passwordLower.IndexOf(reverse, StringComparison.Ordinal) != -1)
                {
                    sequenceAlphasCount++;
                    sequenceCharsCount++;
                }
            }

            // Check for sequential numeric string patterns (forward and reverse).
            for (var s = 0; s < PoolNumerics.Length - 3; s++)
            {
                var forward = PoolNumerics.Substring(s, 3);
                var reverse = Reverse(forward);
                if (passwordLower.IndexOf(forward, StringComparison.Ordinal) != -1 ||
                    passwordLower.IndexOf(reverse, StringComparison.Ordinal) != -1)
                {
                    sequenceNumbersCount++;
                    sequenceCharsCount++;
                }
            }

            // Check for sequential symbol string patterns (forward and reverse).
            for (var s = 0; s < PoolSymbols.Length - 3; s++)
            {
                var forward = PoolSymbols.Substring(s, 3);
                var reverse = Reverse(forward);
                if (passwordLower.IndexOf(forward, StringComparison.Ordinal) != -1 ||
                    passwordLower.IndexOf(reverse, StringComparison.Ordinal) != -1)
                {
                    sequenceSymbolsCount++;
                    sequenceCharsCount++;
                }
            }

            // Modify overall score value based on usage vs requirements.

            // General point assignment.
            if (alphasUpperCount > 0 && alphasUpperCount < password.Length)
            {
                score += (password.Length - alphasUpperCount) * 2;
            }
            if (alphasLowerCount > 0 && alphasLowerCount < password.Length)
            {
                score += (password.Length - alphasLowerCount) * 2;
            }
            if (digitsCount > 0 && digitsCount < password.Length)
            {
                score += digitsCount * FactorNumber;
            }
            if (symbolsCount > 0)
            {
                score += symbolsCount * FactorSymbol;
            }
            if (middleCharsCount > 0)
            {
                score += middleCharsCount * FactorMiddleChar;
            }

            // Point deductions for poor practices.

            // Only Letters.
            if ((alphasLowerCount > 0 || alphasUpperCount > 0) && symbolsCount == 0 && digitsCount == 0)
            {
                score = score - password.Length;
                alphasOnlyCount = password.Length;
            }
            // Only Numbers.
            if (alphasLowerCount == 0 && alphasUpperCount == 0 && symbolsCount == 0 && digitsCount > 0)
            {
                score = score - password.Length;
                numbersOnlyCount = password.Length;
            }
            // Same character exists more than once.
            if (repeatCharsCount > 0)
            {
                score = (int)(score - repeatIncrement);
            }
            // Consecutive uppercase letters exist.
            if (consequenceAlphasUpperCount > 0)
            {
                score -= consequenceAlphasUpperCount * FactorConsequenceAlphaUpper;
            }
            // Consecutive lowercase letters exist.
            if (consequenceAlphasLowerCount > 0)
            {
                score -= consequenceAlphasLowerCount * FactorConsequenceAlphaLower;
            }
            // Consecutive numbers exist.
            if (consequenceDigitsCount > 0)
            {
                score -= consequenceDigitsCount * FactorConsequenceNumber;
            }
            // Sequential alpha strings exist (3 characters or more).
            if (sequenceAlphasCount > 0)
            {
                score -= sequenceAlphasCount * FactorSequenceAlpha;
            }
            // Sequential numeric strings exist (3 characters or more).
            if (sequenceNumbersCount > 0)
            {
                score -= sequenceNumbersCount * FactorSequenceNumber;
            }
            // Sequential symbol strings exist (3 characters or more).
            if (sequenceSymbolsCount > 0)
            {
                score -= sequenceSymbolsCount * FactorSequenceSymbol;
            }

            // Determine if mandatory requirements have been met and set image indicators accordingly.
            var arrChars = new[] { password.Length, alphasUpperCount, alphasLowerCount, digitsCount, symbolsCount };
            for (var c = 0; c < arrChars.Length; c++)
            {
                // Password length.
                int minValue = c == 0 ? MinimumPasswordLength - 1 : 0;
                if (arrChars[c] == minValue + 1 || arrChars[c] > minValue + 1)
                {
                    requiredCharsCount++;
                }
            }
            requirements = requiredCharsCount;
            var minRequiredChars = password.Length >= MinimumPasswordLength ? 3 : 4;

            // One or more required characters exist.
            if (requirements > minRequiredChars)
            {
                score += requirements * 2;
            }

            // Determine if additional bonuses need to be applied and set image indicators accordingly.
            additions = new Dictionary<Addition, int>(10)
            {
                [Addition.MiddleNumbersOrSymbols] = middleCharsCount,
                [Addition.Requirements] = requirements,
                [Addition.NumberOfCharacters] = alphasOnlyCount,
                [Addition.Symbols] = symbolsCount,
                [Addition.UppercaseLetters] = alphasUpperCount,
                [Addition.LowercaseLetters] = alphasLowerCount,
                [Addition.MiddleNumbersOrSymbols] = middleCharsCount,
                [Addition.LettersOnly] = alphasOnlyCount,
                [Addition.NumbersOnly] = numbersOnlyCount,
                [Addition.RepeatCharacters] = repeatCharsCount,
                [Addition.ConsecutiveUppercaseLetters] = consequenceAlphasUpperCount,
                [Addition.ConsecutiveLowercaseLetters] = consequenceAlphasLowerCount,
                [Addition.ConsecutiveNumbers] = consequenceDigitsCount,
                [Addition.SequentialLetters] = sequenceAlphasCount,
                [Addition.SequentialNumbers] = sequenceNumbersCount,
                [Addition.SequentialSymbols] = sequenceSymbolsCount
            };

            score = score > 100 ? 100 : score;
            score = score < 0 ? 0 : score;

            return score;
        }