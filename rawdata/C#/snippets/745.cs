static async Task UseLibrary()
		{

			// Connect to the online knowledgebase.
			// Note that this doesn't require authentication.
			var client = new MFWSClient("http://kb.cloudvault.m-files.com");

			// Execute a quick search for the query term.
			var results = await client.ObjectSearchOperations.SearchForObjectsByStringAsync(Program.queryTerm);
			Console.WriteLine($"There were {results.Length} results returned.");

			// Get the object property values (not necessary, but shows how to retrieve multiple sets of properties in one call).
			var properties = await client.ObjectPropertyOperations.GetPropertiesOfMultipleObjectsAsync(results.Select(r => r.ObjVer).ToArray());

			// Iterate over the results and output them.
			for(var i=0; i<results.Length; i++)
			{
				// Output the object version details.
				var objectVersion = results[i];
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