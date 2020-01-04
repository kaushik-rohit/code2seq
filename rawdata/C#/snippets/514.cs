[Test, TestCaseSource("RestClients")]
        public void Can_download_Poco_response_as_bytes(IRestClient client)
        {
            byte[] response = client.Get<byte[]>("/poco/Test");

            Assert.That(response.FromUtf8Bytes(), Is.StringContaining("Hello, Test"));
        }