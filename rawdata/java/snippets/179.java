public int depth() {
        if (isLeaf()) {
            return 0;
        }
        int maxDepth = 0;
        List<Tree> kids = children();
        for (Tree kid : kids) {
            int curDepth = kid.depth();
            if (curDepth > maxDepth) {
                maxDepth = curDepth;
            }
        }
        return maxDepth + 1;
    }