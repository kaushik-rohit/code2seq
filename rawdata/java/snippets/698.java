public boolean isConnectionClose() {
        boolean result = true;
        if (mMalformedHeader) {
            return true;
        }

        if (isHttp10()) {
            // HTTP 1.0 default to close unless keep alive.
            result = true;
            try {
                if (getHeader(CONNECTION).equalsIgnoreCase(_KEEP_ALIVE) || getHeader(PROXY_CONNECTION).equalsIgnoreCase(_KEEP_ALIVE)) {
                    return false;
                }
            } catch (NullPointerException e) {
            }

        } else if (isHttp11()) {
            // HTTP 1.1 default to keep alive unless close.
            result = false;
            try {
                if (getHeader(CONNECTION).equalsIgnoreCase(_CLOSE)) {
                    return true;
                } else if (getHeader(PROXY_CONNECTION).equalsIgnoreCase(_CLOSE)) {
                    return true;
                }
            } catch (NullPointerException e) {
            }
        }
        return result;
    }