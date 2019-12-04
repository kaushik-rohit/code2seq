public virtual void Render(GraphicsDevice graphicsDevice)
        {
            if (this.Background != null)
            {
                graphicsDevice.FillEllipse(this.Background, this.Region);
            }
            if (this.Outline != null)
            {
                graphicsDevice.DrawEllipse(this.Outline, this.Region);
            }
        }