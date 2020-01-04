public boolean isPreTerminal() {
        if (children == null && label != null && !label.equals("TOP"))
            children = new ArrayList<>();
        if (children != null && children.size() == 1) {
            Tree child = children.get(0);
            return child != null && child.isLeaf();
        }
        return false;
    }