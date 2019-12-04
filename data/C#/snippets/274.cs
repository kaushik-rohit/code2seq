public static TO Convert<TP, TO>(TP obj)
			where TO : TP
		{
			var settings = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };

			var serial = JsonConvert.SerializeObject(obj, Formatting.None, settings);

			return JsonConvert.DeserializeObject<TO>(serial);
		}