public bool IsInDirectory(string directoryPath)
        {
            if (PageDirectory == null) return false;

            if (Locale == null)
            {
                return PageDirectory.MatchesPath(directoryPath);
            }

            return PageDirectory.MatchesPath(directoryPath, Locale.LocaleId);
        }