public static String sanitizeDefaultPort(String url) {
        int afterSchemeIndex = url.indexOf("://");
        if(afterSchemeIndex < 0) {
            return url;
        }
        String scheme = url.substring(0, afterSchemeIndex);
        int fromIndex = scheme.length() + 3;
        //Let's see if it is an IPv6 Address
        int ipv6StartIndex = url.indexOf('[', fromIndex);
        if (ipv6StartIndex > 0) {
            fromIndex = url.indexOf(']', ipv6StartIndex);
        }
        int portIndex = url.indexOf(':', fromIndex);
        if(portIndex >= 0) {
            int port = Integer.parseInt(url.substring(portIndex + 1));
            if(isDefaultPort(port, scheme)) {
                return url.substring(0, portIndex);
            }
        }
        return url;
    }