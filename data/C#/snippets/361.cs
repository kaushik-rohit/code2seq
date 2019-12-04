public override void DrawImage (OxyImage source,
                                  double srcX,
                                  double srcY,
                                  double srcWidth,
                                  double srcHeight,
                                  double destX,
                                  double destY,
                                  double destWidth,
                                  double destHeight,
                                  double opacity,
                                  bool interpolate)
        {
            var image = GetImage (source);
            if (image != null) {
                Context.Save ();
                var sourceRect = new Rectangle (srcX, srcY, srcWidth, srcHeight);
                var destRect = new Rectangle (destX, destY, destWidth, destHeight);
                Context.DrawImage (image, sourceRect, destRect, opacity);
                Context.Fill ();
                Context.Restore ();
            }
        }