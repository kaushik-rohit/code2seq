private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //
            // Update the position of the overview rect to the point that was clicked.
            //
            Point clickedPoint = e.GetPosition(content);
            double newX = clickedPoint.X - (overviewZoomRectThumb.Width / 2);
            double newY = clickedPoint.Y - (overviewZoomRectThumb.Height / 2);
            Canvas.SetLeft(overviewZoomRectThumb, newX);
            Canvas.SetTop(overviewZoomRectThumb, newY);
        }