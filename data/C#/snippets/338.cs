public override void DrawEllipse (OxyRect rect,
                                    OxyColor fill,
                                    OxyColor stroke,
                                    double thickness)
        {
            var ex = rect.Left + (rect.Width / 2.0);
            var ey = rect.Top + (rect.Height / 2.0);


            if (fill.IsVisible ()) {
                Context.Save ();
                Context.SetColor (fill.ToXwtColor ());

                Context.Translate (ex, ey);
                Context.Scale (1.0, -rect.Height / rect.Width);
                Context.Arc (0.0, 0.0, rect.Width / 2.0, 0, 360);

                Context.ClosePath ();
                Context.Fill ();
                Context.Restore ();
            }

            if (stroke.IsVisible () && thickness > 0) {
                Context.Save ();
                Context.SetColor (stroke.ToXwtColor ());
                Context.SetLineWidth (thickness);

                Context.Translate (ex, ey);
                Context.Scale (1.0, -rect.Height / rect.Width);
                Context.Arc (0.0, 0.0, rect.Width / 2.0, 0, 360);

                Context.ClosePath ();
                Context.Stroke ();
                Context.Restore ();
            }
        }