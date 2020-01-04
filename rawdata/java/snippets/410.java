public void addRemedyIndex(RemedyIndexEventData data) {
        String path = StagePathUtils.getRemedyRoot(data.getPipelineId());
        try {
            zookeeper.create(path + "/" + RemedyIndexEventData.formatNodeName(data), new byte[] {},
                             CreateMode.PERSISTENT);
        } catch (ZkNodeExistsException e) {
            // ignore
        } catch (ZkException e) {
            throw new ArbitrateException("addRemedyIndex", data.getPipelineId().toString(), e);
        }
    }