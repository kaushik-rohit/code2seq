public override void DrawLine (IList<ScreenPoint> points,
                                 OxyColor stroke,
                                 double thickness,
                                 double[] dashArray,
                                 LineJoin lineJoin,
                                 bool aliased)
        {
            if (stroke.IsVisible () && thickness > 0 && points.Count >= 2) {
                // g.SmoothingMode = aliased ? SmoothingMode.None : SmoothingMode.HighQuality; // TODO: Smoothing modes
                Context.Save ();
                Context.SetColor (stroke.ToXwtColor ());
                //Context.Li = lineJoin.ToLineJoin();
                Context.SetLineWidth (thickness);
                if (dashArray != null)
					Context.SetLineDash (0, Array.ConvertAll (dashArray, x => x * thickness));

                Context.MoveTo (points [0].ToXwtPoint (aliased));
                foreach (var point in points.Skip(1)) {
                    Context.LineTo (point.ToXwtPoint (aliased));
                }

                Context.Stroke ();
                Context.Restore ();
            }
        }