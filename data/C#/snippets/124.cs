public dynamic GetProperty(string ID, MappingHolder Mappings, string Property, params string[] EmbeddedProperties)
        {
            if (string.IsNullOrEmpty(ID))
                throw new ArgumentNullException(nameof(ID));
            var PropertyObject = Properties.FirstOrDefault(x => string.Equals(x.Name, Property, StringComparison.InvariantCultureIgnoreCase));
            if (PropertyObject == null)
                return null;
            var Object = AnyFunc(ID);
            if (!CanGetFunc(Object))
                return null;
            return PropertyObject.GetValue(Mappings, Object);
        }