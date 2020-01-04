public URL signUrlWithSigner(String bucketName, String blobName, String keyPath)
      throws IOException {
    // [START signUrlWithSigner]
    URL signedUrl =
        storage.signUrl(
            BlobInfo.newBuilder(bucketName, blobName).build(),
            14,
            TimeUnit.DAYS,
            SignUrlOption.signWith(
                ServiceAccountCredentials.fromStream(new FileInputStream(keyPath))));
    // [END signUrlWithSigner]
    return signedUrl;
  }