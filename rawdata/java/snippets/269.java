@Override
  public boolean isHistoryEnabled() {
    if (log.isDebugEnabled()) {
      log.debug("Current history level: {}", historyLevel);
    }
    return !historyLevel.equals(HistoryLevel.NONE);
  }