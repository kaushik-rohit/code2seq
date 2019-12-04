[Test, TestCaseSource("RestClients")]
        public void Can_download_Streams_response_Async(IServiceClient client)
        {
            //Note: The populated MemoryStream which bufferred the response is returned (i.e. after the response is read async-ly)

            byte[] bytes = null;
            var guid = Guid.NewGuid();
            client.GetAsync(new Streams { Text = guid.ToString() }, stream => {
                using (stream)
                {
                    bytes = stream.ReadFully();
                }
            }, (stream, ex) => Assert.Fail(ex.Message));

            Thread.Sleep(2000);

            Assert.That(new Guid(bytes), Is.EqualTo(guid));
        }