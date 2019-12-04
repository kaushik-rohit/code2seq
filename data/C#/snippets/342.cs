public override void DrawPolygon (IList<ScreenPoint> points,
                                    OxyColor fill,
                                    OxyColor stroke,
                                    double thickness,
                                    double[] dashArray,
                                    LineJoin lineJoin,
                                    bool aliased)
        {
            if (fill.IsVisible () && points.Count >= 2) {
                // g.SmoothingMode = aliased ? SmoothingMode.None : SmoothingMode.HighQuality; // TODO: Smoothing modes
                Context.Save ();
                Context.SetColor (fill.ToXwtColor ());
                //Context.LineJoin = lineJoin.ToLineJoin();
				Context.SetLineWidth (thickness);
                if (dashArray != null)
					Context.SetLineDash (0, Array.ConvertAll (dashArray, x => x * thickness));

                Context.MoveTo (points [0].ToXwtPoint (aliased));
                foreach (var point in points.Skip(1)) {
                    Context.LineTo (point.ToXwtPoint (aliased));
                }

                // g.LineTo(points[0].ToPointD(aliased));
                Context.ClosePath ();
                Context.Fill ();
                Context.Restore ();
            }

            if (stroke.IsVisible () && thickness > 0 && points.Count >= 2) {
                // g.SmoothingMode = aliased ? SmoothingMode.None : SmoothingMode.HighQuality; // TODO: Smoothing modes
                Context.Save ();
                Context.SetColor (stroke.ToXwtColor ());
                //Context.LineJoin = lineJoin.ToLineJoin();
                Context.SetLineWidth (thickness);
                if (dashArray != null)
					Context.SetLineDash (0, Array.ConvertAll (dashArray, x => x * thickness));

                Context.MoveTo (points [0].ToXwtPoint (aliased));
                foreach (var point in points.Skip(1)) {
                    Context.LineTo (point.ToXwtPoint (aliased));
                }

                Context.ClosePath ();
                Context.Stroke ();
                Context.Restore ();
            }
        }