public String getCallbackUrl(String challenge) {
        return "http://"
                + Model.getSingleton().getOptionsParam().getProxyParam().getProxyIp() + ":"
                + Model.getSingleton().getOptionsParam().getProxyParam().getProxyPort() + "/"
                + getPrefix() + "/"
                + challenge;
    }