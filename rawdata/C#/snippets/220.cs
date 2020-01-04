protected void SetGlobalOption (String name, String value, bool on) {
            Option option;
            Log(Level.Debug, "Name: {0}", name);
            Log(Level.Debug, "Value: {0}",value);
            Log(Level.Debug, "On: {0}", on);

            if (GlobalOptions.Contains(name)) {
                option = (Option)GlobalOptions[name];
            } else {
                option = new Option();
                option.OptionName = name;
                option.Value = value;
                GlobalOptions.Add(option.OptionName, option);
            } 
            option.IfDefined = on;
        }