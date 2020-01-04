public  void markNodeOffline(@NonNull Node node) {
        synchronized (node) {
            node.status(NodeStatus.OFFLINE);

            for (val n : node.getDownstreamNodes())
                remapNode(n);
        }
    }