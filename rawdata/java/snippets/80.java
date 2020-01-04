public static String getJwtFromAuthorization(String authorization) {
        String jwt = null;
        if(authorization != null) {
            String[] parts = authorization.split(" ");
            if (parts.length == 2) {
                String scheme = parts[0];
                String credentials = parts[1];
                Pattern pattern = Pattern.compile("^Bearer$", Pattern.CASE_INSENSITIVE);
                if (pattern.matcher(scheme).matches()) {
                    jwt = credentials;
                }
            }
        }
        return jwt;
    }