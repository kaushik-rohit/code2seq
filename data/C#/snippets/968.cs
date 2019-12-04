public static IList<object> Serialise<TType>(IList<TType> list, Func<TType, object> elementCallback)
        {
            var output = new List<object>();
            
            foreach (var obj in list)
            {
                ReleaseAssert.IsNotNull(obj, "List elements should not be null.");
                
                var serialisedObj = elementCallback(obj);
                ReleaseAssert.IsTrue(serialisedObj is bool || serialisedObj is int || serialisedObj is long || serialisedObj is float || serialisedObj is string || 
                                     serialisedObj is IList<object> || serialisedObj is IDictionary<string, object>, "Serialised element must be a valid Json type.");
                
                output.Add(serialisedObj);
            }
            
            return output;
        }