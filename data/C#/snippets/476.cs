internal static void ToWave(this CGPoint cGPoint, ref Vector2 waveVector)
        {
            waveVector.X = (float)cGPoint.X;
            waveVector.Y = (float)cGPoint.Y;
        }