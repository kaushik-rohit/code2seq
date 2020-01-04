public override ElementLocalizability GetElementLocalizability(
            string assembly,
            string className
            )
        {
            ElementLocalizability loc = new ElementLocalizability();

            Type type = GetType(assembly, className);            
            if (type != null)
            {
                // We found the type, now try to get the localizability attribte from the type
                loc.Attribute = GetLocalizabilityFromType(type);
            }            
            
            // fill in the formatting tag
            int index = Array.IndexOf(FormattedElements, className);
            if (index >= 0)
            {
                loc.FormattingTag = FormattingTag[index];
            }

            return loc;
        }