public static void shutdown(int status) {
    if(status == 0) H2O.orderlyShutdown();
    UDPRebooted.T.error.send(H2O.SELF);
    H2O.exit(status);
  }