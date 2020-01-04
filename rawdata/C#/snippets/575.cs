public override void OnPointerPressed(Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            PointerPoint pointer = e.GetCurrentPoint(Map);
            Point2D item = Map.ScreenToMap(pointer.Position);
            startPt = item;

            if (!isActivated)
            {
                this.Activate(item);
            }
            e.Handled = true;
            base.OnPointerPressed(e);
        }