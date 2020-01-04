public void setAllowCircularRedirects(boolean allow) {
        client.getParams().setBooleanParameter(HttpClientParams.ALLOW_CIRCULAR_REDIRECTS, allow);
        clientViaProxy.getParams().setBooleanParameter(HttpClientParams.ALLOW_CIRCULAR_REDIRECTS, allow);
    }