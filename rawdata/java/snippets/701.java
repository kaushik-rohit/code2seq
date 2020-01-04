private void initOppositeMainStemStatus() {
        String path = null;
        try {
            path = StagePathUtils.getOppositeMainStem(getPipelineId());
            byte[] bytes = zookeeper.readData(path);
            initOppositeMainStemStatus(bytes);
        } catch (ZkNoNodeException e) {
            // mainstem节点挂了后，状态直接修改为taking
            oppositeMainStemStatus = MainStemEventData.Status.TAKEING;
            permitSem();
        } catch (ZkException e) {
            logger.error(path, e);
        }
    }