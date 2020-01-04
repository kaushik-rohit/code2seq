public IResource FindResource(string name)
        {
            if (Resources.ContainsKey(name))
            {
                return Resources[name];
            }

            IDotvvmResourceRepository parent;
            if (name.Contains(':'))
            {
                var split = name.Split(new[] { ':' }, 2);
                if (Parents.TryGetValue(split[0], out parent))
                {
                    return parent.FindResource(split[1]);
                }
            }

            if (Parents.TryGetValue("", out parent))
            {
                var resource = parent.FindResource(name);
                if (resource != null) return resource;
            }
            return null;
        }