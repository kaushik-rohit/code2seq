[NotNull]
        public string TrimText
            (
                [NotNull] string text
            )
        {
            if (
                text.Length == 0
                || IsAlpha(text[0])
                && IsAlpha(text[text.Length - 1])
               )
            {
                return text;
            }

            StringBuilder builder = new StringBuilder(text);

            // Trim beginning of the text
            while (builder.Length != 0
                   && !IsAlpha(builder[0]))
            {
                builder.Remove(0, 1);
            }

            // Trim tail of the text
            while (builder.Length != 0
                   && !IsAlpha(builder[builder.Length - 1]))
            {
                builder.Remove(builder.Length - 1, 1);
            }

            return builder.ToString();
        }