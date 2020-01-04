[Test, TestCaseSource("RestClients")]
        public void Can_download_StreamWroter_response(IRestClient client)
        {
            var guid = Guid.NewGuid();
            Stream response = client.Get(new StreamWriters { Text = guid.ToString() });
            using (response)
            {
                var bytes = response.ReadFully();
                Assert.That(new Guid(bytes), Is.EqualTo(guid));
            }
        }