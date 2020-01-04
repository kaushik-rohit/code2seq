public boolean isPermittedAddress(String addr) {
        if (addr == null || addr.isEmpty()) {
            return false;
        }

        for (DomainMatcher permAddr : permittedAddressesEnabled) {
            if (permAddr.matches(addr)) {
                return true;
            }
        }
        return false;
    }