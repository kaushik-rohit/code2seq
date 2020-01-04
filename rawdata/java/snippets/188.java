private boolean executeConnect() 
        throws IOException, HttpException {

        this.connectMethod = new ConnectMethod(this.hostConfiguration);
        this.connectMethod.getParams().setDefaults(this.hostConfiguration.getParams());
        String agent = (String) getParams().getParameter(PARAM_DEFAULT_USER_AGENT_CONNECT_REQUESTS);
        if (agent != null) {
            this.connectMethod.setRequestHeader("User-Agent", agent);
        }
        
        int code;
        for (;;) {
            if (!this.conn.isOpen()) {
                this.conn.open();
            }
            if (this.params.isAuthenticationPreemptive()
                    || this.state.isAuthenticationPreemptive()) {
                LOG.debug("Preemptively sending default basic credentials");
                this.connectMethod.getProxyAuthState().setPreemptive();
                this.connectMethod.getProxyAuthState().setAuthAttempted(true);
            }
            try {
                authenticateProxy(this.connectMethod);
            } catch (AuthenticationException e) {
                LOG.error(e.getMessage(), e);
            }
            applyConnectionParams(this.connectMethod);                    
            this.connectMethod.execute(state, this.conn);
            code = this.connectMethod.getStatusCode();
            boolean retry = false;
            AuthState authstate = this.connectMethod.getProxyAuthState(); 
            authstate.setAuthRequested(code == HttpStatus.SC_PROXY_AUTHENTICATION_REQUIRED);
            if (authstate.isAuthRequested()) {
                if (processAuthenticationResponse(this.connectMethod)) {
                    retry = true;
                }
            }
            if (!retry) {
                break;
            }
            if (this.connectMethod.getResponseBodyAsStream() != null) {
                this.connectMethod.getResponseBodyAsStream().close();
            }
        }
        if ((code >= 200) && (code < 300)) {
            this.conn.tunnelCreated();
            // Drop the connect method, as it is no longer needed
            this.connectMethod = null;
            return true;
        } else {
            return false;
        }
    }