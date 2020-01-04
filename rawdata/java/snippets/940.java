private void selfCheckingMove(
      String s3Bucket,
      String targetS3Bucket,
      String s3Path,
      String targetS3Path,
      String copyMsg
  ) throws IOException, SegmentLoadingException
  {
    if (s3Bucket.equals(targetS3Bucket) && s3Path.equals(targetS3Path)) {
      log.info("No need to move file[s3://%s/%s] onto itself", s3Bucket, s3Path);
      return;
    }
    if (s3Client.doesObjectExist(s3Bucket, s3Path)) {
      final ListObjectsV2Result listResult = s3Client.listObjectsV2(
          new ListObjectsV2Request()
              .withBucketName(s3Bucket)
              .withPrefix(s3Path)
              .withMaxKeys(1)
      );
      // Using getObjectSummaries().size() instead of getKeyCount as, in some cases
      // it is observed that even though the getObjectSummaries returns some data
      // keyCount is still zero.
      if (listResult.getObjectSummaries().size() == 0) {
        // should never happen
        throw new ISE("Unable to list object [s3://%s/%s]", s3Bucket, s3Path);
      }
      final S3ObjectSummary objectSummary = listResult.getObjectSummaries().get(0);
      if (objectSummary.getStorageClass() != null &&
          StorageClass.fromValue(StringUtils.toUpperCase(objectSummary.getStorageClass())).equals(StorageClass.Glacier)) {
        throw new AmazonServiceException(
            StringUtils.format(
                "Cannot move file[s3://%s/%s] of storage class glacier, skipping.",
                s3Bucket,
                s3Path
            )
        );
      } else {
        log.info("Moving file %s", copyMsg);
        final CopyObjectRequest copyRequest = new CopyObjectRequest(s3Bucket, s3Path, targetS3Bucket, targetS3Path);
        if (!config.getDisableAcl()) {
          copyRequest.setAccessControlList(S3Utils.grantFullControlToBucketOwner(s3Client, targetS3Bucket));
        }
        s3Client.copyObject(copyRequest);
        if (!s3Client.doesObjectExist(targetS3Bucket, targetS3Path)) {
          throw new IOE(
              "After copy was reported as successful the file doesn't exist in the target location [%s]",
              copyMsg
          );
        }
        deleteWithRetriesSilent(s3Bucket, s3Path);
        log.debug("Finished moving file %s", copyMsg);
      }
    } else {
      // ensure object exists in target location
      if (s3Client.doesObjectExist(targetS3Bucket, targetS3Path)) {
        log.info(
            "Not moving file [s3://%s/%s], already present in target location [s3://%s/%s]",
            s3Bucket, s3Path,
            targetS3Bucket, targetS3Path
        );
      } else {
        throw new SegmentLoadingException(
            "Unable to move file %s, not present in either source or target location",
            copyMsg
        );
      }
    }
  }