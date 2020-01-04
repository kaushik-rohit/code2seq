protected override void Update(GameTime gameTime)
        {
            if (this.IsActive)
            {
                BoundHandler.UpdateMouseInput(gameTime);
                KeyboardHandler.UpdateKeyboardInput(gameTime);
            }

            base.Update(gameTime);
        }