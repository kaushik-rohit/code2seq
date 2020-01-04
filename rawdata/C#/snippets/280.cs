protected override void Draw(GameTime gameTime)
        {
            this.DisplayInGame();
            FMODUtil.System.update();
            this.GraphicsDevice.SetRenderTarget(null);
            this.GraphicsDevice.Clear(Color.Black);

            if (Game1.SplashDone)
            {
                this.SpriteBatch.Begin();
                RenderingPipe.DrawScreen(ref this.SpriteBatch);
                this.SpriteBatch.End();
            }
            else
            {
                int length = Game1.SplashScreens.Count;
                for (int i = 0; i < length; i++)
                {
                    LogoScreen item = Game1.SplashScreens[i];
                    if (!item.Done())
                    {
                        item.Draw(ref this.SpriteBatch);
                        break;
                    }

                    if (i == length - 1)
                    {
                        Game1.SplashDone = true;

                        //Initialize main menu
                        GUI.MainMenu.MainMenu.Initialize();
                        this.IsMouseVisible = true;
                    }
                }
            }

            base.Draw(gameTime);
        }