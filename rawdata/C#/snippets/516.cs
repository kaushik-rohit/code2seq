[Test, TestCaseSource("RestClients")]
        public void Can_download_Poco_response_as_Stream(IRestClient client)
        {
            Stream response = client.Get<Stream>("/poco/Test");
            using (response)
            {
                var bytes = response.ReadFully();
                Assert.That(bytes.FromUtf8Bytes(), Is.StringContaining("Hello, Test"));
            }
        }