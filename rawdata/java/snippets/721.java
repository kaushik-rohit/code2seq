public static void main(String[] args) throws Exception {
    CustomHeaderClient client = new CustomHeaderClient("localhost", 50051);
    try {
      /* Access a service running on the local machine on port 50051 */
      String user = "world";
      if (args.length > 0) {
        user = args[0]; /* Use the arg as the name to greet if provided */
      }
      client.greet(user);
    } finally {
      client.shutdown();
    }
  }