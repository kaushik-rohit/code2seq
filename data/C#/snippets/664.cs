[Test]
        [Ignore("manual test")]
        public void ConsumerFailure()
        {
            string topic = "TestTopicIssue13-2-3R-1P";
            using (var router = new BrokerRouter(_options))
            {
                var producer = new Producer(router);
                var offsets = producer.GetTopicOffsetAsync(topic).Result;
                var maxOffsets = offsets.Select(x => new OffsetPosition(x.PartitionId, x.Offsets.Max())).ToArray();
                var consumerOptions = new ConsumerOptions(topic, router) { PartitionWhitelist = new List<int>() { 0 }, MaxWaitTimeForMinimumBytes = TimeSpan.Zero };

                SandMessageForever(producer, topic);
                ReadMessageForever(consumerOptions, maxOffsets);
            }
        }