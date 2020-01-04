public override void DrawText (ScreenPoint p,
                                 string text,
                                 OxyColor fill,
                                 string fontFamily,
                                 double fontSize,
                                 double fontWeight,
                                 double rotate,
                                 HorizontalAlignment halign,
                                 VerticalAlignment valign,
                                 OxySize? maxSize)
        {
            Context.Save ();

            var layout = new TextLayout ();
            layout.Font = GetCachedFont (fontFamily, fontSize, fontWeight);
            layout.Text = text;

            var size = layout.GetSize ();
            if (maxSize != null) {
                size.Width = Math.Min (size.Width, maxSize.Value.Width);
                size.Height = Math.Min (size.Height, maxSize.Value.Height);
            }

            double dx = 0;
            if (halign == HorizontalAlignment.Center) {
                dx = -size.Width / 2;
            }

            if (halign == HorizontalAlignment.Right) {
                dx = -size.Width;
            }

            double dy = 0;
            if (valign == VerticalAlignment.Middle) {
                dy = -size.Height / 2;
            }

            if (valign == VerticalAlignment.Bottom) {
                dy = -size.Height;
            }

            Context.Translate (p.X, p.Y);
            if (Math.Abs (rotate) > double.Epsilon) {
                Context.Rotate (rotate);
            }

            Context.Translate (dx, dy);

            Context.SetColor (fill.ToXwtColor ());
            Context.DrawTextLayout (layout, 0, 0);

            Context.Restore ();
        }