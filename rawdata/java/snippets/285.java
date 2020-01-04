private JsonParserIterator<DataSegment> getMetadataSegments(
      DruidLeaderClient coordinatorClient,
      ObjectMapper jsonMapper,
      BytesAccumulatingResponseHandler responseHandler,
      Set<String> watchedDataSources
  )
  {
    String query = "/druid/coordinator/v1/metadata/segments";
    if (watchedDataSources != null && !watchedDataSources.isEmpty()) {
      log.debug(
          "filtering datasources in published segments based on broker's watchedDataSources[%s]", watchedDataSources);
      final StringBuilder sb = new StringBuilder();
      for (String ds : watchedDataSources) {
        sb.append("datasources=").append(ds).append("&");
      }
      sb.setLength(sb.length() - 1);
      query = "/druid/coordinator/v1/metadata/segments?" + sb;
    }
    Request request;
    try {
      request = coordinatorClient.makeRequest(
          HttpMethod.GET,
          StringUtils.format(query),
          false
      );
    }
    catch (IOException e) {
      throw new RuntimeException(e);
    }
    ListenableFuture<InputStream> future = coordinatorClient.goAsync(
        request,
        responseHandler
    );

    final JavaType typeRef = jsonMapper.getTypeFactory().constructType(new TypeReference<DataSegment>()
    {
    });
    return new JsonParserIterator<>(
        typeRef,
        future,
        request.getUrl().toString(),
        null,
        request.getUrl().getHost(),
        jsonMapper,
        responseHandler
    );
  }