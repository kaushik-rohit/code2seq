private static IMessageData CreateNewMessageDataInstance(Type type)
        {
            if (typeof(IMessageData).IsAssignableFrom(type))
            {
                if (!MessageDataConstructorDictionary.TryGetValue(type, out var ctor))
                {
                    ctor = type.GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance).First();
                    MessageDataConstructorDictionary.TryAdd(type, ctor);
                }

                return ctor.Invoke(null) as IMessageData;
            }

            throw new Exception("Cannot implement this object!");
        }