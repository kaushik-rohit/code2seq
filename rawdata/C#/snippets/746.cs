static async Task UseApiDirectly()
		{
			// Build the url to request (note to encode the query term).
			var url =
				new Uri("http://kb.cloudvault.m-files.com/REST/objects?q=" + System.Net.WebUtility.UrlEncode(Program.queryTerm));

			// Build the request.
			var httpClient = new HttpClient();

			// Start the request.
			var responseBody = await httpClient.GetStringAsync(url);

			// Output the body.
			// System.Console.WriteLine($"Raw content returned: {responseBody}.");

			// Attempt to parse it.  For this we will use the Json.NET library, but you could use others.
			var results = JsonConvert.DeserializeObject<Results<ObjectVersion>>(responseBody);
			Console.WriteLine($"There were {results.Items.Count} results returned.");

			// Get the object property values (not necessary, but shows how to retrieve multiple sets of properties in one call).
			url = new Uri("http://kb.cloudvault.m-files.com/REST/objects/properties;"
				        + Program.GetObjVersString(results.Items.Select(r => r.ObjVer)));
			responseBody = await httpClient.GetStringAsync(url);
			var properties = JsonConvert.DeserializeObject<PropertyValue[][]>(responseBody);

			// Iterate over the results and output them.
			for (var i = 0; i < results.Items.Count; i++)
			{
				// Output the object version details.
				var objectVersion = results.Items[i];
				Console.WriteLine($"\t{objectVersion.Title}");
				Console.WriteLine($"\t\tType: {objectVersion.ObjVer.Type}, ID: {objectVersion.ObjVer.ID}");

				// Output the properties.
				var objectProperties = properties[i];
				foreach (var property in objectProperties)
				{
					Console.WriteLine($"\t\tProperty: {property.PropertyDef}, Value: {property.TypedValue.Value}");
				}
			}

		}