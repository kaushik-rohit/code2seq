public void setCredentials(final UsernamePasswordCredential credential) {
        val wss4jSecurityInterceptor = new Wss4jSecurityInterceptor();
        wss4jSecurityInterceptor.setSecurementActions("Timestamp UsernameToken");
        wss4jSecurityInterceptor.setSecurementUsername(credential.getUsername());
        wss4jSecurityInterceptor.setSecurementPassword(credential.getPassword());
        setInterceptors(new ClientInterceptor[]{wss4jSecurityInterceptor});
    }