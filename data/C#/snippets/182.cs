public override void FillPath(Graphics g, GraphicsPath gp)
        {
            if (Picture == null) return;
            if (Scale.X == 0 || Scale.Y == 0) return;
            if (Scale.X * Picture.Width * Scale.Y * Picture.Height > 8000 * 8000) return; // The scaled image is too large, will cause memory exceptions.

            Bitmap scaledBitmap = new Bitmap((int)(Picture.Width * Scale.X), (int)(Picture.Height * Scale.Y));
            Graphics scb = Graphics.FromImage(scaledBitmap);
            scb.DrawImage(Picture, new Rectangle(0, 0, scaledBitmap.Width, scaledBitmap.Height), new Rectangle(0, 0, Picture.Width, Picture.Height), GraphicsUnit.Pixel);

            TextureBrush tb = new TextureBrush(scaledBitmap, WrapMode);
            tb.RotateTransform(-(float)Angle);
            g.FillPath(tb, gp);
            tb.Dispose();
            scb.Dispose();
            base.FillPath(g, gp);
        }