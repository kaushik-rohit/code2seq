public RedBlackTreeIterator<T> Find(T item)
		{
			RedBlackTreeIterator<T> it = LowerBound(item);
			while (it.IsValid && host.Compare(it.Current, item) == 0) {
				if (host.Equals(it.Current, item))
					return it;
				it.MoveNext();
			}
			return default(RedBlackTreeIterator<T>);
		}