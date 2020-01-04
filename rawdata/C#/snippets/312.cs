public virtual Request BuildUrl(Dictionary<string, string> parameters)
        {
            const string TypeParam = "Type";
            if (parameters == null || !parameters.ContainsKey("Type"))
                throw new ArgumentException("You must set Type.", TypeParam);

            Type = RequestProcessorHelper.ParseQueryEnumType<ControlStreamType>(parameters["Type"]);

            switch (Type)
            {
                case ControlStreamType.Followers:
                    return BuildFollowersUrl(parameters);
                case ControlStreamType.Info:
                    return BuildInfoUrl(parameters);
                default:
                    throw new InvalidOperationException("The default case of BuildUrl should never execute because a Type must be specified.");
            }
        }