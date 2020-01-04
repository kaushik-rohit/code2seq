protected LoginContext getLoginContext(final UsernamePasswordCredential credential) throws GeneralSecurityException {
        val callbackHandler = new UsernamePasswordCallbackHandler(credential.getUsername(), credential.getPassword());
        if (this.loginConfigurationFile != null && StringUtils.isNotBlank(this.loginConfigType)
            && this.loginConfigurationFile.exists() && this.loginConfigurationFile.canRead()) {
            final Configuration.Parameters parameters = new URIParameter(loginConfigurationFile.toURI());
            val loginConfig = Configuration.getInstance(this.loginConfigType, parameters);
            return new LoginContext(this.realm, null, callbackHandler, loginConfig);
        }
        return new LoginContext(this.realm, callbackHandler);
    }