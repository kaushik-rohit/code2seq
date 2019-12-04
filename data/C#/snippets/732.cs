public override bool Equals(object obj)
        {
            if (!(obj is ScalarValue sv)) return false;
            return Equals(Value, sv.Value);
        }