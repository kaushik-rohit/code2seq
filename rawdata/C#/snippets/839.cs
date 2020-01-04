public void Long_running_consumer_survives_broker_restart()
        {
            using (var publishBus = RabbitHutch.CreateBus("host=localhost;timeout=60"))
            using (var subscribeBus = RabbitHutch.CreateBus("host=localhost"))
            {
                subscribeBus.PubSub.Subscribe<MyMessage>("longRunner", message =>
                    {
                        Console.Out.WriteLine("Got message: {0}", message.Text);
                        Thread.Sleep(2000);
                        Console.Out.WriteLine("Completed  : {0}", message.Text);
                    });

                var counter = 0;
                while (true)
                {
                    Thread.Sleep(1000);
                    publishBus.PubSub.Publish(new MyMessage
                        {
                            Text = string.Format("Hello <{0}>", counter)
                        });
                    counter++;
                }
            }
        }