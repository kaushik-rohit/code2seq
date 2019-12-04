public override string ResolveFormattingTagToClass(
            string formattingTag
            )
        {
            int index = Array.IndexOf(FormattingTag, formattingTag);
            if (index >= 0)
                return FormattedElements[index];
            else
                return null;   
        }