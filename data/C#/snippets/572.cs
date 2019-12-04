public override void Deactivate()
        {
            isActivated = false;
            isDrawing = false;
            ellipse = null;
            if (DrawLayer != null)
            {
                DrawLayer.Children.Clear();
            }
            if (Map != null && Map.Layers != null)
            {
                Map.Layers.Remove(DrawLayer);
            }
        }