public override int GetHashCode()
        {
            var x = EqualityComparer<TSender>.Default.GetHashCode(Sender);
            var y = EqualityComparer<TEventArgs>.Default.GetHashCode(EventArgs);
            return (x << 5) + (x ^ y);
        }