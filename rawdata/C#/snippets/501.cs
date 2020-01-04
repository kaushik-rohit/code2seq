public static int GetMessageCount(Type type)
        {
            if (type == null)
                return MessageDictionary.SelectMany(v => v.Value).Count();
            return MessageDictionary.TryGetValue(type.Name, out var list) ? list.Count : 0;
        }