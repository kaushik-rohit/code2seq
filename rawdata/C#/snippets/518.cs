[Test, TestCaseSource("RestClients")]
        public void Can_download_Headers_response(IRestClient client)
        {
            HttpWebResponse response = client.Get(new Headers { Text = "Test" });
            Assert.That(response.Headers["X-Response"], Is.EqualTo("Test"));
        }