@Override
  public WebElement findElement() {
    SlowLoadingElement loadingElement = new SlowLoadingElement(clock, timeOutInSeconds);
    try {
      return loadingElement.get().getElement();
    } catch (NoSuchElementError e) {
      throw new NoSuchElementException(
          String.format("Timed out after %d seconds. %s", timeOutInSeconds, e.getMessage()),
          e.getCause());
    }
  }