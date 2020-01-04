public void SendMessage(Address remote_addr, ICopyable data) {
      // This instantiates a multi-use method to sending to the remote node,
      // though we will only use it once.  It is VERY similar to UDP.
      AHExactSender sender = new AHExactSender(_app_node.Node, remote_addr);
      // This is the process of actually sending the data.
      sender.Send(new CopyList(HW, data));
    }