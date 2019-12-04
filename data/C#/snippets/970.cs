public static IDictionary<string, object> Serialise<TType>(IDictionary<string, TType> map, Func<TType, object> elementCallback)
        {
            var output = new Dictionary<string, object>();
            
            foreach (var entry in map)
            {
                ReleaseAssert.IsNotNull(entry.Key, "Map keys should not be null.");
                ReleaseAssert.IsNotNull(entry.Value, "Map elements should not be null.");
                
                var serialisedObj = elementCallback(entry.Value);
                ReleaseAssert.IsNotNull(serialisedObj, "Serialised list elements should not be null.");
                ReleaseAssert.IsTrue(serialisedObj is bool || serialisedObj is int || serialisedObj is long || serialisedObj is float || serialisedObj is string || 
                                     serialisedObj is IList<object> || serialisedObj is IDictionary<string, object>, "Serialised element must be a valid Json type.");
                
                output.Add(entry.Key, serialisedObj);
            }
            
            return output;
        }