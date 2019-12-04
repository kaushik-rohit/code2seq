public void RegisterNamedParent(string name, IDotvvmResourceRepository parent)
        {
            ValidateResourceName(name);
            Parents[name] = parent;
        }