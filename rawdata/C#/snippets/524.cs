[Test, TestCaseSource("RestClients")]
        public void Can_download_Bytes_response(IRestClient client)
        {
            var guid = Guid.NewGuid();
            byte[] response = client.Get(new Bytes { Text = guid.ToString() });
            Assert.That(new Guid(response), Is.EqualTo(guid));
        }