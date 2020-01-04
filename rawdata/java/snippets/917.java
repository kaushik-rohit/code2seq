void start() {
    Runnable r;
    for (int i = 0; i < threadCount; i++) {
      r = null;
      switch (config.getPayloadConfig().getPayloadCase()) {
        case SIMPLE_PARAMS: {
          if (config.getClientType() == Control.ClientType.SYNC_CLIENT) {
            if (config.getRpcType() == Control.RpcType.UNARY) {
              r = new BlockingUnaryWorker(blockingStubs[i % blockingStubs.length]);
            }
          } else if (config.getClientType() == Control.ClientType.ASYNC_CLIENT) {
            if (config.getRpcType() == Control.RpcType.UNARY) {
              r = new AsyncUnaryWorker(asyncStubs[i % asyncStubs.length]);
            } else if (config.getRpcType() == Control.RpcType.STREAMING) {
              r = new AsyncPingPongWorker(asyncStubs[i % asyncStubs.length]);
            }
          }
          break;
        }
        case BYTEBUF_PARAMS: {
          if (config.getClientType() == Control.ClientType.SYNC_CLIENT) {
            if (config.getRpcType() == Control.RpcType.UNARY) {
              r = new GenericBlockingUnaryWorker(channels[i % channels.length]);
            }
          } else if (config.getClientType() == Control.ClientType.ASYNC_CLIENT) {
            if (config.getRpcType() == Control.RpcType.UNARY) {
              r = new GenericAsyncUnaryWorker(channels[i % channels.length]);
            } else if (config.getRpcType() == Control.RpcType.STREAMING) {
              r = new GenericAsyncPingPongWorker(channels[i % channels.length]);
            }
          }

          break;
        }
        default: {
          throw Status.UNIMPLEMENTED.withDescription(
              "Unknown payload case " + config.getPayloadConfig().getPayloadCase().name())
              .asRuntimeException();
        }
      }
      if (r == null) {
        throw new IllegalStateException(config.getRpcType().name()
            + " not supported for client type "
            + config.getClientType());
      }
      fixedThreadPool.execute(r);
    }
    if (osBean != null) {
      lastMarkCpuTime = osBean.getProcessCpuTime();
    }
  }