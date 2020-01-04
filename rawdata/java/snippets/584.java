private V findSmallest(Node node) {
        if (node == null) {
            return null;
        }

        while (node.left != null) {
            node = node.left;
        }

        return node.item;
    }