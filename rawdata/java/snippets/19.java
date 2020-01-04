public CallOptions withExecutor(@Nullable Executor executor) {
    CallOptions newOptions = new CallOptions(this);
    newOptions.executor = executor;
    return newOptions;
  }