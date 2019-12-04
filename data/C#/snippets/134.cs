public override string ToString()
        {
            if (IsError)
                return Site.ToString();

            return string.Format(Properties.Resources.Dependency_ToStringFormat, Site, Target.Contract, Target.Origin);
        }