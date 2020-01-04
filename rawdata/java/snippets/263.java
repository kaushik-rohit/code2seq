@Override
    public void upload(String path, InputStream payload, long payloadSize) {
        try {
            ObjectMetadata objectMetadata = new ObjectMetadata();
            objectMetadata.setContentType(CONTENT_TYPE);
            objectMetadata.setContentLength(payloadSize);
            PutObjectRequest request = new PutObjectRequest(bucketName, path, payload, objectMetadata);
            s3Client.putObject(request);
        } catch (SdkClientException e) {
            String msg = "Error communicating with S3";
            logger.error(msg, e);
            throw new ApplicationException(ApplicationException.Code.BACKEND_ERROR, msg, e);
        }
    }