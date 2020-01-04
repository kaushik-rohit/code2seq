public URLNormalizer replaceIPWithDomainName() {
        URL u = toURL();
        if (!PATTERN_DOMAIN.matcher(u.getHost()).matches()) {
            try {
                InetAddress addr = InetAddress.getByName(u.getHost());
                String host = addr.getHostName();
                if (!u.getHost().equalsIgnoreCase(host)) {
                    url = url.replaceFirst(u.getHost(), host);
                }
            } catch (UnknownHostException e) {
                logger.debug("Cannot resolve IP to host for :" + u.getHost(), e);
            }
        }
        return this;
    }