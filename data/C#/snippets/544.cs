protected override void Initialize()
        {
            base.Initialize();

            if (this.UseVirtualScreenSize)
            {
                var virtualScreenManager = this.RenderManager.ActiveCamera2D.UsedVirtualScreen;
                this.Size = new Vector2(virtualScreenManager.VirtualWidth, virtualScreenManager.VirtualHeight);
            }

            if (this.kinectService != null)
            {
                this.colorFactorX = this.Size.X / (float)this.kinectService.ColorTexture.Width;
                this.colorFactorY = this.Size.Y / (float)this.kinectService.ColorTexture.Height;
                this.depthFactorX = this.Size.X / (float)this.kinectService.DepthTexture.Width;
                this.depthFactorY = this.Size.Y / (float)this.kinectService.DepthTexture.Height;
            }
        }