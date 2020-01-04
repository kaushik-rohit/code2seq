private static void ResetOverflowLayout(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            // When dramatic changes occur, rebuild the column layout from scratch
            var target = d as RichTextColumns;
            if (target != null)
            {
                target._overflowColumns = null;
                target.Children.Clear();
                target.InvalidateMeasure();
            }
        }