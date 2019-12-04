public RedBlackTreeIterator<T> Begin()
		{
			if (root == null) return default(RedBlackTreeIterator<T>);
			return new RedBlackTreeIterator<T>(root.LeftMost);
		}