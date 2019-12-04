internal static T Create<T>(GameObject parent) where T : Component, new()
        {
            T component = new T();
            component.Parent = parent;
            return component;
        }