public override void Run() {
      // This handles the whole process of preparing the Brunet.Node.
      _app_node = CreateNode(_node_config);
      // Each Brunet.Node contains a DemuxHandler, this object allows us to
      // request that any message with a specific PType arrive here at the
      // HandleData method.  In this case, we want the PType("HelloWorld"),
      // to arrive here, and without state.
      _app_node.Node.DemuxHandler.GetTypeSource(HW).Subscribe(this, null);

      // Services include XmlRpcManager and Dht over XmlRpcManager
      // Start the Brunet.Node and allow it to connect to remote nodes
      Thread thread = new Thread(_app_node.Node.Connect);
      thread.Start();

      // We finally are at the hello world
      // This is our address, you can copy and paste this locally and at other
      // sites to communicate
      Console.WriteLine("Your address is: " + _app_node.Node.Address + "\n");

      // We will continue on, until we get to the Disconnected states.  Assumming
      // you are running this on a supported platform, that would be triggered 
      // initially by ctrl-c
      while(_app_node.Node.ConState != Node.ConnectionState.Disconnected) {
        // First we need the address of the remote node
        Console.Write("Send message to: ");
        string address_string = Console.ReadLine().Trim(new char[] {' ', '\t'});
        Address addr = null;
        try {
          addr = AddressParser.Parse(address_string);
        } catch {
          Console.WriteLine("Invalid address!\n");
          continue;
        }

        // Get a message
        Console.Write("Message: ");
        string message = Console.ReadLine();

        //Call the Send Message passing in a MemBlock which happens to implement ICopyable
        SendMessage(addr, MemBlock.Reference(Encoding.UTF8.GetBytes(message)));
        Console.WriteLine("Sent...\n");
      }
    }