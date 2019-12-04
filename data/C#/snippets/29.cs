protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            switch (e.Key)
            {
                case Key.Left:
                    this.HorizontalOffset -= 0.001f;
                    break;
                case Key.Right:
                    this.HorizontalOffset += 0.001f;
                    break;
            }
        }