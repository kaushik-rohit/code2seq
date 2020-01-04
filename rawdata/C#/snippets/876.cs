private static void ConfigureDefaultConventions(NancyConventions conventions)
        {
            conventions.CultureConventions = new List<Func<NancyContext, CultureInfo>>
            {
                BuiltInCultureConventions.FormCulture,
                BuiltInCultureConventions.HeaderCulture,
                BuiltInCultureConventions.SessionCulture,
                BuiltInCultureConventions.CookieCulture,
                BuiltInCultureConventions.ThreadCulture
            };
        }