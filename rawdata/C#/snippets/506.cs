private static IMessageBase CreateNewMessageInstance(Type type)
        {
            if (typeof(IMessageBase).IsAssignableFrom(type))
            {
                if (!MessageConstructorDictionary.TryGetValue(type, out var ctor))
                {
                    ctor = type.GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance).First();
                    MessageConstructorDictionary.TryAdd(type, ctor);
                }

                return ctor.Invoke(null) as IMessageBase;
            }

            throw new Exception("Cannot implement this object!");
        }