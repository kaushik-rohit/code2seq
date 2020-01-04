private int inOrderAnalyse(StructuralNode node) {
        int subtreeNodes = 0;

        if (isStop) {
            return 0;
        }

        if (node == null) {
            return 0;
        }

        // analyse entity if not root and not leaf.
        // Leaf is not analysed because only folder entity is used to determine if path exist.
        try {
            if (!node.isRoot()) {
                if (!node.isLeaf() || node.isLeaf() && node.getParent().isRoot()) {
                    analyse(node);
                    
                } else {
                    //ZAP: it's a Leaf then no children are available
                    return 1;
                }
            }
            
        } catch (Exception e) {
        }

        Iterator<StructuralNode> iter = node.getChildIterator();
        while (iter.hasNext()) {
            subtreeNodes += inOrderAnalyse(iter.next());
        }
        
        return subtreeNodes + 1;
    }