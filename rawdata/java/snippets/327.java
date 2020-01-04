public byte[] readBlobFromId(String bucketName, String blobName, long blobGeneration) {
    // [START readBlobFromId]
    BlobId blobId = BlobId.of(bucketName, blobName, blobGeneration);
    byte[] content = storage.readAllBytes(blobId);
    // [END readBlobFromId]
    return content;
  }