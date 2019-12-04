public object Create(object parent, object configContext, XmlNode section)
        {
            if (section != null)
            {
                XmlNodeList aliases = ((XmlElement) section).GetElementsByTagName(AliasElementName);
                foreach (XmlElement aliasElement in aliases)
                {
                    string alias = GetRequiredAttributeValue(aliasElement, NameAttributeName, section);
                    string typeName = GetRequiredAttributeValue(aliasElement, TypeAttributeName, section);
                    TypeRegistry.RegisterType(alias, typeName);
                }
            }
            return null;
        }