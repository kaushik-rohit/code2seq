public override void DrawRectangle (OxyRect rect,
                                      OxyColor fill,
                                      OxyColor stroke,
                                      double thickness)
        {
            if (fill.IsVisible ()) {
                Context.Save ();
                Context.Rectangle (rect.ToXwtRect (false));
                Context.SetColor (fill.ToXwtColor ());
                Context.Fill ();
                Context.Restore ();
            }

            if (stroke.IsVisible () && thickness > 0) {
                Context.Save ();
                Context.SetColor (stroke.ToXwtColor ());
                Context.SetLineWidth (thickness);
                Context.Rectangle (rect.ToXwtRect (false));
                Context.Stroke ();
                Context.Restore ();
            }
        }