public static int EstimatePasswordStrength([NotNull] string password)
        {
            IDictionary<Addition, int> additions;
            return EstimatePasswordStrength(password, out additions);
        }