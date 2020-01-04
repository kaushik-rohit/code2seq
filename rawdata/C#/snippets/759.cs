public static async Task<JsonObject> ChangesAsync (this SalesforceClient self, IAuthenticatedRequest request)
        {
            Response response;

            try {
                response = await self.ProcessAsync (request);
            } catch (AggregateException ex) {
                throw ex.Flatten ().InnerException;
            }

            var result = response.GetResponseText ();
            var jsonValue = JsonValue.Parse (result);

            if (jsonValue == null)
                throw new Exception ("Could not parse Json data");

            return (JsonObject)jsonValue;
        }