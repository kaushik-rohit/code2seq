public override int GetHashCode()
        {
            unchecked
            {
                const int prime = -1521134295;
                var hash = 12345701;
                hash = hash * prime + EqualityComparer<string>.Default.GetHashCode(Path);
                hash = hash * prime + EqualityComparer<string>.Default.GetHashCode(Reason);
                return hash;
            }
        }