public void setCookies(List<HttpCookie> cookies) {
        if (cookies.isEmpty()) {
            setHeader(HttpHeader.COOKIE, null);
        }

        StringBuilder sbData = new StringBuilder();

        for (HttpCookie c : cookies) {
            sbData.append(c.getName());
            sbData.append('=');
            sbData.append(c.getValue());
            sbData.append("; ");
        }

        if (sbData.length() <= 3) {
            setHeader(HttpHeader.COOKIE, null);
            return;
        }

        final String data = sbData.substring(0, sbData.length() - 2);
        setHeader(HttpHeader.COOKIE, data);
    }