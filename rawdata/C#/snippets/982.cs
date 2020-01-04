public static void rotate(
                double inX, double inY,
                double angle,
                out double outX, out double outY)
            {
                double sin = Math.Sin(angle);
                double cos = Math.Cos(angle);
                outX = inX * sin + inY * cos;
                outY = -inX * cos + inY * sin;
            }