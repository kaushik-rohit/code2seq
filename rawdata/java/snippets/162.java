private BookKeeper startBookKeeperClient() throws Exception {
        // These two are in Seconds, not Millis.
        int writeTimeout = (int) Math.ceil(this.config.getBkWriteTimeoutMillis() / 1000.0);
        int readTimeout = (int) Math.ceil(this.config.getBkReadTimeoutMillis() / 1000.0);
        ClientConfiguration config = new ClientConfiguration()
                .setClientTcpNoDelay(true)
                .setAddEntryTimeout(writeTimeout)
                .setReadEntryTimeout(readTimeout)
                .setGetBookieInfoTimeout(readTimeout)
                .setClientConnectTimeoutMillis((int) this.config.getZkConnectionTimeout().toMillis())
                .setZkTimeout((int) this.config.getZkConnectionTimeout().toMillis());

        if (this.config.isTLSEnabled()) {
            config = (ClientConfiguration) config.setTLSProvider("OpenSSL");
            config = config.setTLSTrustStore(this.config.getTlsTrustStore());
            config.setTLSTrustStorePasswordPath(this.config.getTlsTrustStorePasswordPath());
        }

        String metadataServiceUri = "zk://" + this.config.getZkAddress();
        if (this.config.getBkLedgerPath().isEmpty()) {
            metadataServiceUri += "/" + this.namespace + "/bookkeeper/ledgers";
        } else {
            metadataServiceUri += this.config.getBkLedgerPath();
        }
        config.setMetadataServiceUri(metadataServiceUri);

        return new BookKeeper(config);
    }