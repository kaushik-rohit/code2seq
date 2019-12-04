[Test, TestCaseSource("RestClients")]
        public void Can_download_Poco_response_as_string(IRestClient client)
        {
            string response = client.Get<string>("/poco/Test");

            Assert.That(response, Is.StringContaining("Hello, Test"));
        }