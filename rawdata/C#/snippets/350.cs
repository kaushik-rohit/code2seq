public override OxySize MeasureText (string text,
                                       string fontFamily,
                                       double fontSize,
                                       double fontWeight)
        {
            if (text == null)
                return OxySize.Empty;

            var layout = new TextLayout ();
            layout.Font = GetCachedFont (fontFamily, fontSize, fontWeight);
            layout.Text = text;

            var size = layout.GetSize ();
            return new OxySize (size.Width, size.Height);
        }