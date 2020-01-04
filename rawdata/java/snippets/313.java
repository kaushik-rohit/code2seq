public static ConnectionConfig newLdaptiveConnectionConfig(final AbstractLdapProperties l) {
        if (StringUtils.isBlank(l.getLdapUrl())) {
            throw new IllegalArgumentException("LDAP url cannot be empty/blank");
        }

        LOGGER.debug("Creating LDAP connection configuration for [{}]", l.getLdapUrl());
        val cc = new ConnectionConfig();

        val urls = l.getLdapUrl().contains(" ")
            ? l.getLdapUrl()
            : String.join(" ", l.getLdapUrl().split(","));
        LOGGER.debug("Transformed LDAP urls from [{}] to [{}]", l.getLdapUrl(), urls);
        cc.setLdapUrl(urls);

        cc.setUseSSL(l.isUseSsl());
        cc.setUseStartTLS(l.isUseStartTls());
        cc.setConnectTimeout(Beans.newDuration(l.getConnectTimeout()));
        cc.setResponseTimeout(Beans.newDuration(l.getResponseTimeout()));

        if (StringUtils.isNotBlank(l.getConnectionStrategy())) {
            val strategy = AbstractLdapProperties.LdapConnectionStrategy.valueOf(l.getConnectionStrategy());
            switch (strategy) {
                case RANDOM:
                    cc.setConnectionStrategy(new RandomConnectionStrategy());
                    break;
                case DNS_SRV:
                    cc.setConnectionStrategy(new DnsSrvConnectionStrategy());
                    break;
                case ACTIVE_PASSIVE:
                    cc.setConnectionStrategy(new ActivePassiveConnectionStrategy());
                    break;
                case ROUND_ROBIN:
                    cc.setConnectionStrategy(new RoundRobinConnectionStrategy());
                    break;
                case DEFAULT:
                default:
                    cc.setConnectionStrategy(new DefaultConnectionStrategy());
                    break;
            }
        }

        if (l.getTrustCertificates() != null) {
            LOGGER.debug("Creating LDAP SSL configuration via trust certificates [{}]", l.getTrustCertificates());
            val cfg = new X509CredentialConfig();
            cfg.setTrustCertificates(l.getTrustCertificates());
            cc.setSslConfig(new SslConfig(cfg));
        } else if (l.getTrustStore() != null || l.getKeystore() != null) {
            val cfg = new KeyStoreCredentialConfig();
            if (l.getTrustStore() != null) {
                LOGGER.trace("Creating LDAP SSL configuration with truststore [{}]", l.getTrustStore());
                cfg.setTrustStore(l.getTrustStore());
                cfg.setTrustStoreType(l.getTrustStoreType());
                cfg.setTrustStorePassword(l.getTrustStorePassword());
            }
            if (l.getKeystore() != null) {
                LOGGER.trace("Creating LDAP SSL configuration via keystore [{}]", l.getKeystore());
                cfg.setKeyStore(l.getKeystore());
                cfg.setKeyStorePassword(l.getKeystorePassword());
                cfg.setKeyStoreType(l.getKeystoreType());
            }
            cc.setSslConfig(new SslConfig(cfg));
        } else {
            LOGGER.debug("Creating LDAP SSL configuration via the native JVM truststore");
            cc.setSslConfig(new SslConfig());
        }

        val sslConfig = cc.getSslConfig();
        if (sslConfig != null) {
            switch (l.getHostnameVerifier()) {
                case ANY:
                    sslConfig.setHostnameVerifier(new AllowAnyHostnameVerifier());
                    break;
                case DEFAULT:
                default:
                    sslConfig.setHostnameVerifier(new DefaultHostnameVerifier());
                    break;
            }
        }

        if (StringUtils.isNotBlank(l.getSaslMechanism())) {
            LOGGER.debug("Creating LDAP SASL mechanism via [{}]", l.getSaslMechanism());

            val bc = new BindConnectionInitializer();
            val sc = getSaslConfigFrom(l);

            if (StringUtils.isNotBlank(l.getSaslAuthorizationId())) {
                sc.setAuthorizationId(l.getSaslAuthorizationId());
            }
            sc.setMutualAuthentication(l.getSaslMutualAuth());
            if (StringUtils.isNotBlank(l.getSaslQualityOfProtection())) {
                sc.setQualityOfProtection(QualityOfProtection.valueOf(l.getSaslQualityOfProtection()));
            }
            if (StringUtils.isNotBlank(l.getSaslSecurityStrength())) {
                sc.setSecurityStrength(SecurityStrength.valueOf(l.getSaslSecurityStrength()));
            }
            bc.setBindSaslConfig(sc);
            cc.setConnectionInitializer(bc);
        } else if (StringUtils.equals(l.getBindCredential(), "*") && StringUtils.equals(l.getBindDn(), "*")) {
            LOGGER.debug("Creating LDAP fast-bind connection initializer");
            cc.setConnectionInitializer(new FastBindOperation.FastBindConnectionInitializer());
        } else if (StringUtils.isNotBlank(l.getBindDn()) && StringUtils.isNotBlank(l.getBindCredential())) {
            LOGGER.debug("Creating LDAP bind connection initializer via [{}]", l.getBindDn());
            cc.setConnectionInitializer(new BindConnectionInitializer(l.getBindDn(), new Credential(l.getBindCredential())));
        }
        return cc;
    }