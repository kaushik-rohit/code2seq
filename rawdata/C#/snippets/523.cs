[Test, TestCaseSource("RestClients")]
        public void Can_download_Strings_response_Async(IServiceClient client)
        {
            string response = null;
            client.GetAsync(new Strings { Text = "Test" }, r => response = r,
                (r, ex) => Assert.Fail(ex.Message));

            Thread.Sleep(2000);

            Assert.That(response, Is.EqualTo("Hello, Test"));
        }