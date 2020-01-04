public static DeviceModel Get(string baseUrl, string deviceId, string accessToken)
        {
            var client = new RestClient(baseUrl);
            var request = new RestRequest(deviceId + "/model", Method.GET);
            if (!string.IsNullOrEmpty(accessToken)) request.AddQueryParameter("access_token", accessToken);

            var response = client.Execute(request);
            if (response != null && response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var json = response.Content;
                if (!string.IsNullOrEmpty(json))
                {
                    var obj = Json.Convert.FromJson<DeviceModel>(json);
                    if (obj != null)
                    {
                        obj.DeviceId = deviceId;
                        return obj;
                    }
                }
            }

            return null;
        }