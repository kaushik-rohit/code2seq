public static int GetMessageDataCount(Type type)
        {
            if (type == null)
                return MessageDataDictionary.SelectMany(v => v.Value).Count();
            return MessageDataDictionary.TryGetValue(type.Name, out var list) ? list.Count : 0;
        }