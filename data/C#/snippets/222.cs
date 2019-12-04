protected void SetCommandOption (String name, String value, bool on) {
            Option option;
            if (CommandOptions.Contains(name)) {
                option = (Option)CommandOptions[name];
            } else {
                option = new Option();
                option.OptionName = name;
                option.Value = value;
                CommandOptions.Add(name, option);
            } 
            option.IfDefined = on;
        }