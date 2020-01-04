private void writeMessageEmbeddedWebServerIpPort(Socket s) throws Exception {
    writeType(s, TYPE_EMBEDDED_WEB_SERVER_IP_PORT);
    writeString(s, _embeddedWebServerIp);
    writeInt(s, _embeddedWebServerPort);
  }