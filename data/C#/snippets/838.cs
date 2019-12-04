public void Server_goes_away_and_comes_back_during_subscription()
        {
            //Task.Factory.StartNew(OccasionallyKillConnections, TaskCreationOptions.LongRunning);

            Console.WriteLine("Creating busses");
            using (var busA = RabbitHutch.CreateBus("host=localhost"))
            using (var busB = RabbitHutch.CreateBus("host=localhost"))
            {
                Console.WriteLine("About to subscribe");

                // ping pong between busA and busB
                busB.PubSub.Subscribe<FromA>("restarted", message => Reply<FromB>(message, busB, "B"));
                busA.PubSub.Subscribe<FromB>("restarted_1", message => Reply<FromA>(message, busA, "A"));

                Console.WriteLine("Subscribed");

                busA.PubSub.Publish(new FromA { Text = "Initial From A ", Id = 0 });

                while (true)
                {
                    Thread.Sleep(2000);
                }
            }
        }