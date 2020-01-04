private Status statusFromTrailers(Metadata trailers) {
    Status status = trailers.get(InternalStatus.CODE_KEY);
    if (status != null) {
      return status.withDescription(trailers.get(InternalStatus.MESSAGE_KEY));
    }
    // No status; something is broken. Try to provide a resonanable error.
    if (headersReceived) {
      return Status.UNKNOWN.withDescription("missing GRPC status in response");
    }
    Integer httpStatus = trailers.get(HTTP2_STATUS);
    if (httpStatus != null) {
      status = GrpcUtil.httpStatusToGrpcStatus(httpStatus);
    } else {
      status = Status.INTERNAL.withDescription("missing HTTP status code");
    }
    return status.augmentDescription(
        "missing GRPC status, inferred error from HTTP status code");
  }