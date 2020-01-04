public RedBlackTreeIterator<T> GetEnumerator()
		{
			if (root == null) return default(RedBlackTreeIterator<T>);
			RedBlackTreeNode<T> dummyNode = new RedBlackTreeNode<T>(default(T));
			dummyNode.right = root;
			return new RedBlackTreeIterator<T>(dummyNode);
		}