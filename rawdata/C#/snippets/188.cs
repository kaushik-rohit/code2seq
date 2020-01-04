public void Register(string name, IResource resource, bool replaceIfExists = true)
        {
            if (resource == null)
            {
                throw new ArgumentNullException(nameof(resource));
            }

            ValidateResourceName(name);
            ValidateResourceLocation(resource, name);
            if (replaceIfExists)
            {
                Resources.AddOrUpdate(name, resource, (key, res) => resource);
            }
            else if (!Resources.TryAdd(name, resource))
            {
                throw new InvalidOperationException($"A resource with the name '{name}' is already registered!");
            }
        }