public RedBlackTreeIterator<T> UpperBound(T item)
		{
			RedBlackTreeIterator<T> it = LowerBound(item);
			while (it.IsValid && host.Compare(it.Current, item) == 0) {
				it.MoveNext();
			}
			return it;
		}