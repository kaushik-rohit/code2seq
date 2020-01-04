public static InternalProtocolNegotiator.ProtocolNegotiator tls(SslContext sslContext) {
    final io.grpc.netty.ProtocolNegotiator negotiator = ProtocolNegotiators.tls(sslContext);
    final class TlsNegotiator implements InternalProtocolNegotiator.ProtocolNegotiator {

      @Override
      public AsciiString scheme() {
        return negotiator.scheme();
      }

      @Override
      public ChannelHandler newHandler(GrpcHttp2ConnectionHandler grpcHandler) {
        return negotiator.newHandler(grpcHandler);
      }

      @Override
      public void close() {
        negotiator.close();
      }
    }
    
    return new TlsNegotiator();
  }