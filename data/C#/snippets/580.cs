public bool CompareTo(Shape shape)
        {
            if (shape is PolygonShape && this is PolygonShape)
                return ((PolygonShape)this).CompareTo((PolygonShape)shape);

            if (shape is CircleShape && this is CircleShape)
                return ((CircleShape)this).CompareTo((CircleShape)shape);

            if (shape is EdgeShape && this is EdgeShape)
                return ((EdgeShape)this).CompareTo((EdgeShape)shape);

            if (shape is ChainShape && this is ChainShape)
                return ((ChainShape)this).CompareTo((ChainShape)shape);

            return false;
        }