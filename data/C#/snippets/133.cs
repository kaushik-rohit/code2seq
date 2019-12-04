static bool Ask(string question, bool defaultAnswer)
        {
            Console.Write("{0} ({1}/{2}): ", question, (defaultAnswer ? "Y" : "y"), (!defaultAnswer ? "N" : "n"));
            string input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                return defaultAnswer;
            }

            if(input.ToLower() == "y")
            {
                return true;
            }

            if(input.ToLower() == "n")
            {
                return false;
            }

            return false;
        }