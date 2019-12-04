public String ParseToMarkdown(XElement element)
        {
            if (element.Name != "para")
            {
                return null;
            }

            var seeElements = element.Elements("see");

            foreach (var seeElement in seeElements)
            {
                var parsedSee = this._parserPool.Parse<SeeMarkdownNodeParser>(seeElement);
                if (parsedSee != null)
                {
                    seeElement.SetValue(parsedSee);
                }
            }

            return String.Format("*{0}*", element.Value);
        }