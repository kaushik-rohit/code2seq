public static ReadOnlyDictionary<string, TType> DeserialiseMap<TType>(IDictionary<string, object> map, Func<object, TType> elementCallback)
        {
            var output = new Dictionary<string, TType>();
            
            foreach (var entry in map)
            {
                ReleaseAssert.IsNotNull(entry.Key, "Map keys should not be null.");
                ReleaseAssert.IsNotNull(entry.Value, "Map elements should not be null.");
                ReleaseAssert.IsTrue(entry.Value is bool || entry.Value is int || entry.Value is long || entry.Value is float || entry.Value is string || 
                                     entry.Value is IList<object> || entry.Value is IDictionary<string, object>, "Serialised element must be a valid Json type.");
                
                var deserialisedObj = elementCallback(entry.Value);
                ReleaseAssert.IsNotNull(deserialisedObj, "Deserialised list elements should not be null.");
                
                output.Add(entry.Key, deserialisedObj);
            }
            
            return new ReadOnlyDictionary<string, TType>(output);
        }