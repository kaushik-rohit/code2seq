static void Exit(string reason = "")
        {
            if(Sniffer != null && Sniffer.Running) Sniffer.Stop();

            if(!string.IsNullOrEmpty(reason))
            {
                Console.WriteLine(reason);
            }
            
            Console.Write("Press any key to exit...");
            Console.ReadKey(true);
            Environment.Exit(0);
        }