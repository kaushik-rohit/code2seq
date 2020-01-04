public List<String> keysForBucket(String bucket) {
        AmazonS3 s3 = getClient();
        List<String> ret = new ArrayList<>();
        ListObjectsRequest listObjectsRequest = new ListObjectsRequest().withBucketName(bucket);
        ObjectListing objectListing;

        do {
            objectListing = s3.listObjects(listObjectsRequest);
            for (S3ObjectSummary objectSummary : objectListing.getObjectSummaries()) {
                ret.add(objectSummary.getKey());
            }
            listObjectsRequest.setMarker(objectListing.getNextMarker());
        } while (objectListing.isTruncated());

        return ret;
    }