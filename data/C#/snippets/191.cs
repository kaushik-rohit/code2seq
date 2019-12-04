public void AssertAndLogInvalidModelState(HttpResponseMessage response, HttpStatusCode expected)
        {
            var responseResult = response.Content.ReadAsStringAsync().Result;
            Assert.AreEqual(expected, response.StatusCode, responseResult);
        }