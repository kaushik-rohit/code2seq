internal static PlaneAnchorType ToWave(this ARPlaneAnchorAlignment alignment)
        {
            switch (alignment)
            {
                default:
                case ARPlaneAnchorAlignment.Horizontal:
                    return PlaneAnchorType.HorizontalUpwardFacing;
                case ARPlaneAnchorAlignment.Vertical:
                    return PlaneAnchorType.Vertical;
            }
        }