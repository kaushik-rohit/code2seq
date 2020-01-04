private String getServerTlsFingerPrint() {
        String fingerPrint = null;
        Map<String, Object> serverConfig = Config.getInstance().getJsonMapConfigNoCache("server");
        Map<String, Object> secretConfig = Config.getInstance().getJsonMapConfigNoCache("secret");
        // load keystore here based on server config and secret config
        String keystoreName = (String)serverConfig.get("keystoreName");
        String serverKeystorePass = (String)secretConfig.get("serverKeystorePass");
        if(keystoreName != null) {
            try (InputStream stream = Config.getInstance().getInputStreamFromFile(keystoreName)) {
                KeyStore loadedKeystore = KeyStore.getInstance("JKS");
                loadedKeystore.load(stream, serverKeystorePass.toCharArray());
                X509Certificate cert = (X509Certificate)loadedKeystore.getCertificate("server");
                if(cert != null) {
                    fingerPrint = FingerPrintUtil.getCertFingerPrint(cert);
                } else {
                    logger.error("Unable to find the certificate with alias name as server in the keystore");
                }
            } catch (Exception e) {
                logger.error("Unable to load server keystore ", e);
            }
        }
        return fingerPrint;
    }