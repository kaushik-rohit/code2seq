public override int GetHashCode()
        {
            if (Value == null) return 0;
            return Value.GetHashCode();
        }