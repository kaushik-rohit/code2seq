public override void OnPointerReleased(Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            Point2D item = Map.ScreenToMap(e.GetCurrentPoint(Map).Position);
            double width = Math.Abs(item.X - startPt.X);
            double height = Math.Abs(startPt.Y - item.Y);
            double r = Math.Sqrt(width * width + height * height);
            this._radius = r;
            endDraw(this._radius);
            base.OnPointerReleased(e);
        }