public override void OnPointerMoved(Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            if (isDrawing)
            {
                Point2D item = Map.ScreenToMap(e.GetCurrentPoint(Map).Position);
                double width = Math.Abs(item.X - startPt.X);
                double height = Math.Abs(startPt.Y - item.Y);
                double r = Math.Sqrt(width * width + height * height);
                this._radius = r;
                Rectangle2D bounds = new Rectangle2D(startPt.X - r, startPt.Y - r, startPt.X + r, startPt.Y + r);//圆
                ellipse.SetValue(ElementsLayer.BBoxProperty, bounds);
            }

            base.OnPointerMoved(e);
        }