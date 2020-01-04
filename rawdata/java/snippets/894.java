public String obtainLoopbackIp4Address() {
    final NetworkInterface networkInterface = getLoopBackAndIp4Only();
    if (networkInterface != null) {
      return networkInterface.getIp4LoopbackOnly().getHostName();
    }

    final String ipOfIp4LoopBack = getIpOfLoopBackIp4();
    if (ipOfIp4LoopBack != null) {
      return ipOfIp4LoopBack;
    }

    if (Platform.getCurrent().is(Platform.UNIX)) {
      NetworkInterface linuxLoopback = networkInterfaceProvider.getLoInterface();
      if (linuxLoopback != null) {
        final InetAddress netAddress = linuxLoopback.getIp4LoopbackOnly();
        if (netAddress != null) {
          return netAddress.getHostAddress();
        }
      }
    }

    throw new WebDriverException(
        "Unable to resolve local loopback address, please file an issue with the full message of this error:\n"
            +
            getNetWorkDiags() + "\n==== End of error message");
  }