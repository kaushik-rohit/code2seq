[Test, TestCaseSource("RestClients")]
        public void Can_download_Headers_response_Async(IServiceClient client)
        {
            //Note: HttpWebResponse is returned before any response is read, so it's ideal point for streaming in app code

            HttpWebResponse response = null;
            client.GetAsync(new Headers { Text = "Test" }, r => response = r,
                (r, ex) => Assert.Fail(ex.Message));

            Thread.Sleep(2000);

            Assert.That(response.Headers["X-Response"], Is.EqualTo("Test"));
        }