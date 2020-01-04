public boolean check() {
        String path = ZookeeperPathUtils.getDestinationServerRunning(destination);
        try {
            byte[] bytes = zkClient.readData(path);
            ServerRunningData eventData = JsonUtils.unmarshalFromByte(bytes, ServerRunningData.class);
            activeData = eventData;// 更新下为最新值
            // 检查下nid是否为自己
            boolean result = isMine(activeData.getAddress());
            if (!result) {
                logger.warn("canal is running in node[{}] , but not in node[{}]",
                    activeData.getCid(),
                    serverData.getCid());
            }
            return result;
        } catch (ZkNoNodeException e) {
            logger.warn("canal is not run any in node");
            return false;
        } catch (ZkInterruptedException e) {
            logger.warn("canal check is interrupt");
            Thread.interrupted();// 清除interrupt标记
            return check();
        } catch (ZkException e) {
            logger.warn("canal check is failed");
            return false;
        }
    }