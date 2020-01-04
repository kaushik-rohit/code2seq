public static String shaBase64(String s) {
    try {
      MessageDigest messageDigest = MessageDigest.getInstance("SHA-1");
      byte[] sha1Bytes = messageDigest.digest(s.getBytes("UTF-8"));
      return ByteString.of(sha1Bytes).base64();
    } catch (NoSuchAlgorithmException e) {
      throw new AssertionError(e);
    } catch (UnsupportedEncodingException e) {
      throw new AssertionError(e);
    }
  }