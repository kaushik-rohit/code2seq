public static PrivateKey createPrivateKey(byte[] privateKey) {
    if (privateKey == null) {
      return null;
    }

    try {
      KeyFactory fac = KeyFactory.getInstance("RSA");
      EncodedKeySpec spec = new PKCS8EncodedKeySpec(privateKey);
      return fac.generatePrivate(spec);
    }
    catch (NoSuchAlgorithmException e) {
      throw new IllegalStateException(e);
    }
    catch (InvalidKeySpecException e) {
      throw new IllegalStateException(e);
    }
  }