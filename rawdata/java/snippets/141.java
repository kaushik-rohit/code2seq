public static ExpectedCondition<WebElement> elementToBeClickable(final By locator) {
    return new ExpectedCondition<WebElement>() {
      @Override
      public WebElement apply(WebDriver driver) {
        WebElement element = visibilityOfElementLocated(locator).apply(driver);
        try {
          if (element != null && element.isEnabled()) {
            return element;
          }
          return null;
        } catch (StaleElementReferenceException e) {
          return null;
        }
      }

      @Override
      public String toString() {
        return "element to be clickable: " + locator;
      }
    };
  }