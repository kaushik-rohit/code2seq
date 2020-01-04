[Test, TestCaseSource("RestClients")]
        public void Can_download_Poco_response_as_PocoResponse(IRestClient client)
        {
            HttpWebResponse response = client.Get<HttpWebResponse>("/poco/Test");

            using (var stream = response.GetResponseStream())
            using (var sr = new StreamReader(stream))
            {
                Assert.That(sr.ReadToEnd(), Is.StringContaining("Hello, Test"));
            }
        }