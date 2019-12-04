private static T CreateNewInstance<T>() where T : class
        {
            if (typeof(IMessageData).IsAssignableFrom(typeof(T)))
            {
                if (!MessageDataConstructorDictionary.TryGetValue(typeof(T), out var ctor))
                {
                    ctor = typeof(T).GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance).First();
                    MessageDataConstructorDictionary.TryAdd(typeof(T), ctor);
                }

                return ctor.Invoke(null) as T;
            }
            if (typeof(IMessageBase).IsAssignableFrom(typeof(T)))
            {
                if (!MessageConstructorDictionary.TryGetValue(typeof(T), out var ctor))
                {
                    ctor = typeof(T).GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance).First();
                    MessageConstructorDictionary.TryAdd(typeof(T), ctor);
                }

                return ctor.Invoke(null) as T;
            }

            throw new Exception("Cannot implement this object!");
        }