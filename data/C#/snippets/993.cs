public void Update(GameTime gameTime)
        {
            float tSecond = gameTime.ElapsedGameTime/1000f;
            float gravity = 12f;

            float velocity = gravity*tSecond;

            Velocity = new Vector2(Velocity.X, Velocity.Y + velocity);

            Position += Velocity;
            _spriteSheet.Update(gameTime);
        }