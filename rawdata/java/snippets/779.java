protected boolean isButtonEnabledForSelectedMessages(List<HttpMessage> httpMessages) {
        for (HttpMessage httpMessage : httpMessages) {
            if (httpMessage != null && !isButtonEnabledForSelectedHttpMessage(httpMessage)) {
                return false;
            }
        }
        return true;
    }