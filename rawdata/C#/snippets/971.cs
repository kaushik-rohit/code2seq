public static ReadOnlyCollection<TType> DeserialiseList<TType>(IList<object> list, Func<object, TType> elementCallback)
        {
            var output = new List<TType>();
            
            foreach (var obj in list)
            {
                ReleaseAssert.IsNotNull(obj, "List elements should not be null.");
                ReleaseAssert.IsTrue(obj is bool || obj is int || obj is long || obj is float || obj is string || 
                                     obj is IList<object> || obj is IDictionary<string, object>, "Serialised element must be a valid Json type.");
                
                var deserialisedObj = elementCallback(obj);
                ReleaseAssert.IsNotNull(deserialisedObj, "Deserialised list elements should not be null.");
                
                output.Add(deserialisedObj);
            }
            
            return new ReadOnlyCollection<TType>(output);
        }