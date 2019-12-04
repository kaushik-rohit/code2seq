public void Render(RenderDevice renderer)
        {
            if (!Dead)
            {
                renderer.DrawTexture(_spriteSheet, _position);
            }
            else
            {
                renderer.DrawTexture(_erased, _position);
            }
        }