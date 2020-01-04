public void addEvent(UserFeedbackEvent event) {
    UserFeedbackEvent[] oldEvents = feedbackEvents;
    feedbackEvents = new UserFeedbackEvent[feedbackEvents.length + 1];
    System.arraycopy(oldEvents, 0, feedbackEvents, 0, oldEvents.length);
    feedbackEvents[oldEvents.length] = event;
  }