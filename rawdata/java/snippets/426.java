public double errorSum() {
        if (isLeaf()) {
            return 0.0;
        } else if (isPreTerminal()) {
            return error();
        } else {
            double error = 0.0;
            for (Tree child : children()) {
                error += child.errorSum();
            }
            return error() + error;
        }
    }