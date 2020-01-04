[Test, TestCaseSource("RestClients")]
        public void Can_download_Bytes_response_Async(IServiceClient client)
        {
            byte[] bytes = null;
            var guid = Guid.NewGuid();
            client.GetAsync(new Bytes { Text = guid.ToString() }, r => bytes = r,
                (r, ex) => Assert.Fail(ex.Message));

            Thread.Sleep(2000);

            Assert.That(new Guid(bytes), Is.EqualTo(guid));
        }