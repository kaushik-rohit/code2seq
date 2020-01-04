@Override
  public void eventReceived(EventSubscriptionEntity eventSubscriptionEntity, Object payload, boolean processASync) {
    if (processASync) {
      scheduleEventAsync(eventSubscriptionEntity, payload);
    } else {
      processEventSync(eventSubscriptionEntity, payload);
    }
  }