[Test, TestCaseSource("RestClients")]
        public void Can_download_Poco_response(IRestClient client)
        {
            PocoResponse response = client.Get(new Poco { Text = "Test" });

            Assert.That(response.Result, Is.EqualTo("Hello, Test"));
        }