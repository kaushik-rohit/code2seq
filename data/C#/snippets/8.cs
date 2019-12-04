public bool Equals(EventPattern<TSender, TEventArgs> other)
        {
            if (object.ReferenceEquals(null, other))
                return false;
            if (object.ReferenceEquals(this, other))
                return true;

            return EqualityComparer<TSender>.Default.Equals(Sender, other.Sender) && EqualityComparer<TEventArgs>.Default.Equals(EventArgs, other.EventArgs);
        }