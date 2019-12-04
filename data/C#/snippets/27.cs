public RedBlackTreeIterator<T> LowerBound(T item)
		{
			RedBlackTreeNode<T> node = root;
			RedBlackTreeNode<T> resultNode = null;
			while (node != null) {
				if (host.Compare(node.val, item) < 0) {
					node = node.right;
				} else {
					resultNode = node;
					node = node.left;
				}
			}
			return new RedBlackTreeIterator<T>(resultNode);
		}