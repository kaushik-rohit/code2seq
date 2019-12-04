protected override IEnumerable<KeyValuePair<string, T>> ParseXml()
        {
            XElement root = XElement.Load(reader);
            IEnumerable<XElement> elements = root.Elements(Constants.SignedIdentifier);
            foreach (XElement signedIdentifierElement in elements)
            {
                string id = (string)signedIdentifierElement.Element(Constants.Id);
                T accessPolicy;
                XElement accessPolicyElement = signedIdentifierElement.Element(Constants.AccessPolicy);
                if (accessPolicyElement != null)
                {
                    accessPolicy = this.ParseElement(accessPolicyElement);
                }
                else
                {
                    accessPolicy = new T();
                }

                yield return new KeyValuePair<string, T>(id, accessPolicy);
            }
        }