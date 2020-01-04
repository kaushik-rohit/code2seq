protected boolean isValidAuthority(String authority) {
        if (authority == null) {
            return false;
        }
        
        // check manual authority validation if specified
        if (authorityValidator != null && authorityValidator.isValid(authority)) {
            return true;
        }
        // convert to ASCII if possible
        final String authorityASCII = DomainValidator.unicodeToASCII(authority);
        
        Matcher authorityMatcher = AUTHORITY_PATTERN.matcher(authorityASCII);
        if (!authorityMatcher.matches()) {
            return false;
        }
        
        // We have to process IPV6 separately because that is parsed in a different group
        String ipv6 = authorityMatcher.group(PARSE_AUTHORITY_IPV6);
        if (ipv6 != null) {
            InetAddressValidator inetAddressValidator = InetAddressValidator.getInstance();
            if (!inetAddressValidator.isValidInet6Address(ipv6)) {
                return false;
            }
        } else {
            String hostLocation = authorityMatcher.group(PARSE_AUTHORITY_HOST_IP);
            // check if authority is hostname or IP address:
            // try a hostname first since that's much more likely
            DomainValidator domainValidator = DomainValidator.getInstance(isOn(ALLOW_LOCAL_URLS));
            if (!domainValidator.isValid(hostLocation)) {
                // try an IPv4 address
                InetAddressValidator inetAddressValidator = InetAddressValidator.getInstance();
                if (!inetAddressValidator.isValidInet4Address(hostLocation)) {
                    // isn't IPv4, so the URL is invalid
                    return false;
                }
            }
            String port = authorityMatcher.group(PARSE_AUTHORITY_PORT);
            if (port != null && port.length() > 0) {
                try {
                    int iPort = Integer.parseInt(port);
                    if (iPort < 0 || iPort > MAX_UNSIGNED_16_BIT_INT) {
                        return false;
                    }
                } catch (NumberFormatException nfe) {
                    return false; // this can happen for big numbers
                }
            }
        }
        
        String extra = authorityMatcher.group(PARSE_AUTHORITY_EXTRA);
        if (extra != null && extra.trim().length() > 0){
            return false;
        }
        
        return true;
    }