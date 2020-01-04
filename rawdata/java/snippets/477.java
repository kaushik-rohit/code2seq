public void init() {
        String rootPath = ManagePathUtils.getRoot();
        String channelRootPath = ManagePathUtils.getChannelRoot();
        String nodeRootPath = ManagePathUtils.getNodeRoot();
        try {
            zookeeper.create(rootPath, new byte[0], CreateMode.PERSISTENT);
            zookeeper.create(channelRootPath, new byte[0], CreateMode.PERSISTENT);
            zookeeper.create(nodeRootPath, new byte[0], CreateMode.PERSISTENT);
        } catch (ZkNodeExistsException e) {
            // 如果节点已经存在，则不抛异常
            // ignore
        } catch (ZkException e) {
            throw new ArbitrateException("system_init", e);
        }
    }